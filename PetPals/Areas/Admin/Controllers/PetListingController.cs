using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetPals.Data;
using PetPals.Data.Models;
using PetPals.Services.Data.Interfaces;
using PetPals.Web.ViewModels.PetListing;
using PetPals.Web.ViewModels.PetListing.PetPals.Web.ViewModels;
using System.Security.Claims;

namespace PetPals.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PetListingController : Controller
    {
        private readonly IPetListingService petListingService;
        private readonly IPetService petService;
        private readonly PetPalsDbContext dbContext;

        public PetListingController(IPetListingService petListingService, IPetService petService, PetPalsDbContext dbContext)
        {
            this.petListingService = petListingService;
            this.petService = petService;
            this.dbContext = dbContext;

        }
        public async Task<IActionResult> Index()
        {
            var viewModel = await petListingService.GetAllListingsAsync();
            return View(viewModel);
        }



        [HttpGet]
        public async Task<IActionResult> Approve(Guid id)
        {
            var listing = await petListingService.GetListingByIdAsync(id);
            if (listing == null) return NotFound();

            return View(listing);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveListing(Guid id, string adminComments)
        {
            // Find the listing from the database
            var listing = await dbContext.PetListings.FindAsync(id);
            if (listing == null) throw new Exception("Listing not found");

            if (!listing.IsApproved)
            {
                // Update the listing approval status
                listing.IsApproved = true;
                listing.AdminComments = adminComments;

                // Map the listing details to a PetFormModel
                var petFormModel = new PetFormModel
                {
                    Name = listing.PetStory, // Map relevant data, adjust as needed
                    Species = listing.PetType, // Assuming listing.PetType is the species
                    ShotsUpToDate = listing.ShotsUpToDate,
                    IsHouseTrained = listing.IsHouseTrained,
                    Story = listing.PetStory
                };

                // Use the PetService to add the pet
                await petService.AddPetAsync(petFormModel);

                // Create a user-pet relationship
                var userPet = new ApplicationUserPet
                {
                    ApplicationUserId = listing.UserId,
                    PetId = petFormModel.Id // Use the ID from the saved PetFormModel
                };

                dbContext.ApplicationUserPets.Add(userPet);
            }

            // Save the changes in the database
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }





        [HttpGet]
        public async Task<IActionResult> Reject(Guid id)
        {
            var listing = await petListingService.GetListingByIdAsync(id);
            if (listing == null) return NotFound();

            return View(listing);
        }

        [HttpPost]
        public async Task<IActionResult> Reject(Guid id, string rejectionReason)
        {
            await petListingService.RejectListingAsync(id, rejectionReason);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetListingCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Re-display the form with validation errors
            }


            TempData["Step1Data"] = JsonConvert.SerializeObject(model);

            // Redirect to the AboutYou action in the Pet controller
            return RedirectToAction("AboutYou", "PetListing");
        }




        [HttpGet]
        public IActionResult AboutYou()
        {
            // Retrieve data from TempData (Step 1 data saved earlier)
            var step1DataJson = TempData["Step1Data"] as string;

            // Deserialize the data or create a new instance if TempData is empty
            var step1Data = !string.IsNullOrEmpty(step1DataJson)
                ? JsonConvert.DeserializeObject<PetListingCreateModel>(step1DataJson)
                : new PetListingCreateModel();

            // Create a new AboutYouModel to capture Step 2 inputs
            var aboutYouModel = new PetListingAboutYouModel
            {
                PetType = step1Data.PetType,
                IsNeutered = step1Data.IsNeutered,
                ReasonForRehoming = step1Data.ReasonForRehoming,
                AvailableCarePeriod = step1Data.AvailableCarePeriod,
                PetStory = step1Data.PetStory
            };

            return View(aboutYouModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AboutYou(PetListingAboutYouModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Re-display the form with validation errors
            }

            // Retrieve Step 1 data from TempData
            var step1DataJson = TempData["Step1Data"] as string;
            var step1Data = JsonConvert.DeserializeObject<PetListingCreateModel>(step1DataJson);
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Get current user's ID


            // Combine Step 1 and Step 2 data into a complete PetListing object
            var petListing = new PetListing
            {
                Id = Guid.NewGuid(),
                PetType = step1Data.PetType,
                IsNeutered = step1Data.IsNeutered,
                ReasonForRehoming = step1Data.ReasonForRehoming,
                AvailableCarePeriod = step1Data.AvailableCarePeriod,
                PetStory = step1Data.PetStory,
                UserId = userId,
                IsApproved = false,
                IsRejected = false,
                AdminComments = string.Empty
            };

            // Save the completed pet listing to the database
            //await petListingService.CreateListingAsync(petListing);

            // Redirect to a confirmation or success page
            return RedirectToAction("Confirm");
        }


        [HttpGet]
        public IActionResult YourPet()
        {
            // Retrieve Step 1 and Step 2 data from TempData
            var step1DataJson = TempData["Step1Data"] as string;
            var step2DataJson = TempData["Step2Data"] as string;

            var step1Data = !string.IsNullOrEmpty(step1DataJson)
                ? JsonConvert.DeserializeObject<PetListingCreateModel>(step1DataJson)
                : new PetListingCreateModel();

            var step2Data = !string.IsNullOrEmpty(step2DataJson)
                ? JsonConvert.DeserializeObject<PetListingAboutYouModel>(step2DataJson)
                : new PetListingAboutYouModel();

            // Combine Step 1 and Step 2 data into a single model for Step 3
            var model = new YourPetModel
            {
                PetType = step1Data.PetType,
                ReasonForRehoming = step1Data.ReasonForRehoming,
                AvailableCarePeriod = step1Data.AvailableCarePeriod,
                PetStory = step1Data.PetStory,
                FirstName = step2Data.FirstName,
                LastName = step2Data.LastName,
                Email = step2Data.Email,
                PhoneNumber = step2Data.PhoneNumber
            };

            return View(model);
        }



    }

}
