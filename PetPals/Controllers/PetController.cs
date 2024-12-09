using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetPals.Services.Data;
using PetPals.Services.Data.Interfaces;

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

        public async Task<IActionResult> All()
        {
            var pets = await petService.GetAllPetsAsync(); // Get pets from the service
            return View(pets); // Pass the pets to the view
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

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await petService.DeletePetAsync(id); // Call the service to delete the pet
            return RedirectToAction("Index", "Home"); // Redirect to the listing page
        }
    }
}
