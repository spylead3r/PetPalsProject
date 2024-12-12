using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PetPals.Services.Data;
using PetPals.Services.Data.Interfaces;
using PetPals.Web.ViewModels.Pet;

namespace PetPals.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService petService;

        public PetController(IPetService petService)
        {
                this.petService = petService;
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

            return View(pets); // Pass sorted and filtered pets to the view
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
                return RedirectToAction();
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
                PhotoPath = pet.PhotoPath
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, PetFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await this.petService.UpdatePetAsync(id, model);

            if (!success)
            {
                return NotFound();
            }

            TempData["SuccessMessage"] = "Pet updated successfully!";
            return RedirectToAction("Index", "Home");
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
    }
}
