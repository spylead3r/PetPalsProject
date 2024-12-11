using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetPals.Data;
using PetPals.Data.Models;
using PetPals.Services.Data.Interfaces;
using PetPals.Web.ViewModels.Pet;



namespace PetPals.Services.Data
{
    public class PetService : IPetService
    {
        private readonly PetPalsDbContext dbContext;

        public PetService(PetPalsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<Pet>> GetAllPetsAsync()
        {
            return await dbContext.Pets.ToListAsync(); 
        }



        public async Task<Pet?> GetPetByIdAsync(Guid id)
        {
            return await dbContext.Pets.FindAsync(id);
        }

        public async Task AddPetAsync(PetFormModel formModel)
        {
            Pet pet = new Pet()
            {
                Name = formModel.Name,
                Species = formModel.Species,
                Breed = formModel.Breed,
                Age = formModel.Age,
                HealthStatus = formModel.HealthStatus,
                AdoptionStatus = formModel.AdoptionStatus,
                PhotoPath = formModel.PhotoPath,
            };

            await dbContext.Pets.AddAsync(pet);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdatePetAsync(Pet pet)
        {
            dbContext.Pets.Update(pet);
            await dbContext.SaveChangesAsync();
        }

        public async Task<PetDetailsViewModel?> GetPetDetailsAsync(Guid id)
        {
            return await this.dbContext.Pets
                .Where(p => p.Id == id)
                .Select(p => new PetDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Species = p.Species,
                    Breed = p.Breed,
                    Age = p.Age,
                    HealthStatus = p.HealthStatus,
                    AdoptionStatus = p.AdoptionStatus,
                    PhotoPath = p.PhotoPath
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdatePetAsync(Guid id, PetFormModel model)
        {
            var pet = await this.GetPetByIdAsync(id);

            if (pet == null)
            {
                return false;
            }

            // Update the pet's properties.
            pet.Name = model.Name;
            pet.Species = model.Species;
            pet.Breed = model.Breed;
            pet.Age = model.Age;
            pet.HealthStatus = model.HealthStatus;
            pet.AdoptionStatus = model.AdoptionStatus;
            pet.PhotoPath = model.PhotoPath;

            await this.dbContext.SaveChangesAsync(); // Save changes to the database.
            return true;
        }

        public async Task DeletePetAsync(Guid id)
        {
            var pet = await dbContext.Pets.FindAsync(id);
            if (pet != null)
            {
                dbContext.Pets.Remove(pet);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetTotalPetsCountAsync(string search)
        {
            var query = dbContext.Pets.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.Contains(search) || p.Species.Contains(search));
            }

            return await query.CountAsync();
        }


    }

}
