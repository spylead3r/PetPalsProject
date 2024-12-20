using Microsoft.EntityFrameworkCore;
using PetPals.Data;
using PetPals.Data.Models;
using PetPals.Services.Data.Interfaces;
using PetPals.Web.ViewModels.PetListing;

public class PetListingService : IPetListingService
{
    private readonly PetPalsDbContext dbContext;

    public PetListingService(PetPalsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task CreateListingAsync(PetListingModel model, Guid userId)
    {
        // Map the incoming model to a PetListing entity
        var listing = new PetListing
        {
            Id = Guid.NewGuid(),
            PetType = model.PetType,
            IsNeutered = model.IsNeutered,
            ReasonForRehoming = model.ReasonForRehoming,
            AvailableCarePeriod = model.AvailableCarePeriod,
            ShotsUpToDate = model.ShotsUpToDate,
            IsHouseTrained = model.IsHouseTrained,
            PetStory = model.PetStory,
            UserId = userId,
            IsApproved = false,
            IsRejected = false,
            AdminComments = string.Empty
        };

        // Add the listing to the database
        dbContext.PetListings.Add(listing);

        // Save changes
        await dbContext.SaveChangesAsync();
    }


    public async Task<List<PetListingModel>> GetAllListingsAsync()
    {
        var petListings = await dbContext.PetListings
            .Include(p => p.User) // Include related user
            .Include(p => p.Pet)  // Include related pet
            .ToListAsync();

        return petListings.Select(listing => new PetListingModel
        {
            Id = listing.Id,
            PetType = listing.PetType,
            IsNeutered = listing.IsNeutered,
            ReasonForRehoming = listing.ReasonForRehoming,
            AvailableCarePeriod = listing.AvailableCarePeriod,
            FirstName = listing.User?.FirstName,
            LastName = listing.User?.LastName,
            Email = listing.User?.Email,
            PhoneNumber = listing.User?.PhoneNumber,
            PetName = listing.Pet?.Name,
            ShotsUpToDate = listing.ShotsUpToDate,
            IsHouseTrained = listing.IsHouseTrained,
            PetStory = listing.PetStory,
            IsApproved = listing.IsApproved,
            IsRejected = listing.IsRejected,
            AdminComments = listing.AdminComments
        }).ToList();
    }


    public async Task<PetListing> GetListingByIdAsync(Guid id)
    {
        return await dbContext.PetListings.FindAsync(id);
    }

    public async Task ApproveListingAsync(Guid id, string adminComments)
    {
        var listing = await dbContext.PetListings.FindAsync(id);

        if (listing == null) throw new Exception("Listing not found");

        listing.IsApproved = true;
        listing.AdminComments = adminComments;

        // Create a Pet entity based on the listing details
        var pet = new Pet
        {
            Id = Guid.NewGuid(),
            Name = listing.PetStory, // Adjust this to the correct property
            IsNeutered = listing.IsNeutered,
            ShotsUpToDate = listing.ShotsUpToDate,
            IsHouseTrained = listing.IsHouseTrained,
            Story = listing.PetStory
        };

         dbContext.Pets.Add(pet);

        // Create the user-pet relationship
        var userPet = new ApplicationUserPet
        {
            ApplicationUserId = listing.UserId, // The user who listed the pet
            PetId = pet.Id
        };

        dbContext.ApplicationUserPets.Add(userPet);

        // Save changes to the database
        await dbContext.SaveChangesAsync();
    }


    public async Task RejectListingAsync(Guid id, string adminComments)
    {
        var listing = await dbContext.PetListings.FindAsync(id);
        if (listing != null)
        {
            listing.IsApproved = false;
            listing.AdminComments = adminComments;
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<PetListing>> GetPendingListingsAsync()
    {
        return await dbContext.PetListings
            .Where(listing => !listing.IsApproved && !listing.IsNeutered)
            .ToListAsync();
    }


    public async Task ApproveListingAndAddPetAsync(Guid id, string adminComments)
    {
        // Retrieve the listing
        var listing = await dbContext.PetListings
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (listing == null)
        {
            throw new InvalidOperationException("Listing not found.");
        }

        // Mark listing as approved
        listing.IsApproved = true;
        listing.AdminComments = adminComments;

        // Create a Pet entity based on the listing details
        var pet = new Pet
        {
            Id = Guid.NewGuid(),
            Name = listing.Pet.Name, // Assuming `PetName` is part of the `Pet` model
            Age = listing.Pet.Age, // Assuming `Age` is part of the `Pet` model
            IsNeutered = listing.IsNeutered,
            ShotsUpToDate = listing.ShotsUpToDate,
            IsHouseTrained = listing.IsHouseTrained,
            Story = listing.PetStory,
        };

        var userPet = new ApplicationUserPet
        {
            ApplicationUserId = listing.UserId, // The user who owns the pet
            PetId = pet.Id // The newly created pet
        };

        pet.UserPets.Add(userPet); // Add the relationship
        dbContext.Pets.Add(pet); // Add the pet to the database

        await dbContext.SaveChangesAsync(); // Save changes

  
    }


}
