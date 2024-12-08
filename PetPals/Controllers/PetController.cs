using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Create()
        {
            return View(new PetFormModel());
        }


        public IActionResult Add()
        {
            return View(new PetFormModel());
        }


        [HttpPost]
        public async Task<IActionResult> Add(PetFormModel formModel)
        {
            if (ModelState.IsValid)
            {
                await petService.AddPetAsync(formModel);
                return RedirectToAction(nameof(Index));
            }
            return View(formModel);
        }
    }
}
