using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using PetPals.Data.Models;
using PetPals.Web.ViewModels.User;
using static PetPals.Common.GeneralAppConstants;

namespace PetPals.Web
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserStore<ApplicationUser> userStore;
        private readonly IMemoryCache memoryCache;




        public UserController(SignInManager<ApplicationUser> signInManager,
                             UserManager<ApplicationUser> userManager,
                             IMemoryCache memoryCache)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Register()
        {   
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {


            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
            };

            await this.userManager.SetEmailAsync(user, model.Email);
            await this.userManager.SetUserNameAsync(user, model.Email);

            IdentityResult result =
                await this.userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    if (error.Code.Contains("Password"))
                    {
                        ModelState.AddModelError("Password", error.Description); // Matches asp-for="Password"
                    }
                    else if (error.Code.Contains("Email"))
                    {
                        ModelState.AddModelError("Email", error.Description); // Matches asp-for="Email"
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, error.Description); // General errors
                    }
                }

                return View(model);
            }

            await this.signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] =
                    "Something went wrong! Please try again later or contact an administrator.";
                return View(model);
            }

            Microsoft.AspNetCore.Identity.SignInResult result =
                await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                TempData[ErrorMessage] =
                    "There was an error while logging you in! Please try again later or contact an administrator.";

                return View(model);
            }

            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }



        [HttpPost]
        public async Task<IActionResult> CompleteProfile([FromBody] CompleteProfileModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid data.");
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            // Update user's profile
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;

            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return StatusCode(500, "Error updating profile.");
            }

            return Ok(new { message = "Profile updated successfully!" });
        }


    }
}
