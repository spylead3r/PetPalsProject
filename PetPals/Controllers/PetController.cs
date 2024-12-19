using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json;
using PetPals.Data.Models;
using PetPals.Services.Data;
using PetPals.Services.Data.Interfaces;
using PetPals.Web.ViewModels.Pet;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PetPals.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService petService;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public PetController(IPetService petService, IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.petService = petService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All(string searchInput, string filter, string sortBy)
        {
            var pets = await petService.GetAllPetsAsync();

            // Filter by species
            if (!string.IsNullOrEmpty(filter))
            {
                pets = pets.Where(p => p.Species.Equals(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Search by name or species
            if (!string.IsNullOrEmpty(searchInput))
            {
                pets = pets.Where(p => p.Name.Contains(searchInput, StringComparison.OrdinalIgnoreCase)
                                    || p.Species.Contains(searchInput, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Sort logic
            pets = sortBy switch
            {
                "name" => pets.OrderBy(p => p.Name).ToList(),
                "age" => pets.OrderBy(p => p.Age).ToList(),
                "species" => pets.OrderBy(p => p.Species).ToList(),
                _ => pets.ToList(), // Default: no sorting
            };

            // Prepare query model
            var queryModel = new AllPetsQueryModel
            {
                Pets = pets,
                SearchInput = searchInput,
                Filter = filter,
                SortBy = sortBy
            };

            return View(queryModel); // Pass AllPetsQueryModel to the view
        }








        [HttpGet]
        public IActionResult Add()
        {
            PetFormModel formModel = new PetFormModel();

            return View(formModel);
        }


        [HttpPost]
        public async Task<IActionResult> Add(PetFormModel formModel)
        {
            if (ModelState.IsValid)
            {
                await petService.AddPetAsync(formModel);
                TempData["SuccessMessage"] = "Pet added successfully!";
                return RedirectToAction("Index","Home");
            }

            return View(formModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var pet = await this.petService.GetPetByIdAsync(id); // Fetch the pet from the database.

            if (pet == null)
            {
                return NotFound();
            }

            var model = new PetFormModel()
            {
                Id = pet.Id,
                Name = pet.Name,
                Species = pet.Species,
                Breed = pet.Breed,
                Age = pet.Age,
                HealthStatus = pet.HealthStatus,
                AdoptionStatus = pet.AdoptionStatus,
                ExistingPhotos = pet.Photos.ToList() // Pass existing photos to the ViewModel
            };

            ViewData["ExistingPhotos"] = pet.Photos;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, PetFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if photos are provided -> Run Add Photos Method
                if (model.Photos != null && model.Photos.Any())
                {
                    var addPhoto = await petService.AddPetPhotosAsync(id, model.Photos);

                    if (!addPhoto)
                    {
                        TempData["ErrorMessage"] = "Cannot add more than 3 images!";
                        return RedirectToAction(nameof(Edit), new { id });
                    }

                    TempData["SuccessMessage"] = "New photos added successfully!";
                    return RedirectToAction(nameof(Details), new { id });
                }

                // Check if properties are being updated -> Run Update Pet Method
                if (!string.IsNullOrEmpty(model.Name) || model.Age > 0 || !string.IsNullOrEmpty(model.Breed))
                {
                    var updateProperties = await petService.UpdatePetAsync(id, model);

                    if (!updateProperties)
                    {
                        TempData["ErrorMessage"] = "Failed to update pet details.";
                        return RedirectToAction(nameof(Edit), new { id });
                    }

                    TempData["SuccessMessage"] = "Pet details updated successfully!";
                    return RedirectToAction(nameof(Details), new { id });
                }
            }

            TempData["ErrorMessage"] = "No changes were made.";
            return View(model);
        }





        [HttpPost]
        public async Task<IActionResult> DeletePhoto(Guid photoId)
        {
            var petId = await petService.DeletePhotoAsync(photoId);

            if (petId == null)
            {
                return NotFound(); // Photo not found
            }

            // Redirect back to the Edit page for the associated pet
            return RedirectToAction("Edit", new { id = petId });
        }



        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var pet = await this.petService.GetPetDetailsAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }



        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await petService.DeletePetAsync(id); // Call the service to delete the pet
            return RedirectToAction("Index", "Home"); // Redirect to the listing page
        }

        public async Task<IActionResult> Cats()
        {
            var cats = await petService.GetCatsAsync();
            return View(cats);
        }


        [HttpGet]
        public IActionResult Start()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Start(PetListingModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["PetListing"] = JsonConvert.SerializeObject(model);
                return RedirectToAction("AboutYou");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AboutYou()
        {
            var user = await userManager!.GetUserAsync(User);

            // Check if the profile is complete
            bool isProfileComplete = false;
            if (user != null)
            {
                isProfileComplete = await userService.IsProfileComplete(user.Id);
            }

            ViewData["IsProfileComplete"] = isProfileComplete; // Pass completion status

            var model = GetTempData(); // Model data if needed
            return View(model);
        }



        [HttpPost]
        public IActionResult AboutYou(PetListingModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["PetListing"] = JsonConvert.SerializeObject(model);
                return RedirectToAction("YourPet");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult YourPet()
        {
            var model = GetTempData();
            return View(model);
        }

        [HttpPost]
        public IActionResult YourPet(PetListingModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["PetListing"] = JsonConvert.SerializeObject(model);
                return RedirectToAction("Confirm");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Confirm()
        {
            var model = GetTempData();
            return View(model);
        }

        [HttpPost]
        public IActionResult Confirm(PetListingModel model)
        {
            if (ModelState.IsValid)
            {
                // Save data to database or perform other operations
                // Redirect to Success Page
                return RedirectToAction("Success");
            }
            return View(model);
        }

        private PetListingModel GetTempData()
        {
            if (TempData["PetListing"] != null)
            {
                return JsonConvert.DeserializeObject<PetListingModel>(TempData["PetListing"] as string);
            }
            return new PetListingModel();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}

