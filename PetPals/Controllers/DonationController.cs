using Microsoft.AspNetCore.Mvc;
using PetPals.Data.Models;
using PetPals.Services.Data.Interfaces;

namespace PetPals.Controllers
{
    public class DonationController : Controller
    {
        private readonly IDonationService donationService;

        public DonationController(IDonationService donationService)
        {
            this.donationService = donationService;
        }

        [HttpGet]
        public IActionResult Donate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Donate(Donation model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await donationService.AddDonationAsync(model);

            TempData["SuccessMessage"] = "Thank you for your donation!";
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }

}
