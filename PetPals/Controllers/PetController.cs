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
    }
}
