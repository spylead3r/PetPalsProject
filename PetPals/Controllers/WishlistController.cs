using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetPals.Data.Models;
using PetPals.Services.Data.Interfaces;

namespace PetPals.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly IWishlistService wishlistService;
        private readonly UserManager<ApplicationUser> userManager;

        public WishlistController(IWishlistService wishlistService, UserManager<ApplicationUser> userManager)
        {
            this.wishlistService = wishlistService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = Guid.Parse(userManager.GetUserId(User));
            var wishlist = await wishlistService.GetWishlistAsync(userId);
            return View(wishlist);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Guid petId)
        {
            var userId = Guid.Parse(userManager.GetUserId(User));
            await wishlistService.AddToWishlistAsync(userId, petId);
            TempData["SuccessMessage"] = "Successfully added to wishlist!";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid petId)
        {
            var userId = Guid.Parse(userManager.GetUserId(User));
            await wishlistService.RemoveFromWishlistAsync(userId, petId);
            return RedirectToAction("Index");
        }
    }

}
