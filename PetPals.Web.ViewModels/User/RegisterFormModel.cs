using System.ComponentModel.DataAnnotations;
using static PetPals.Common.EntityValidationConstants.ApplicationUser;

namespace PetPals.Web.ViewModels.User
{
    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
            ErrorMessage = "The {0} must be at least {2} characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        //[Required(ErrorMessage = "First name is required.")]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string? FirstName { get; set; }

        //[Required(ErrorMessage = "Last name is required.")]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string? LastName { get; set; }


        //[Required(ErrorMessage = "Phone number is required.")]
        [StringLength(PhoneNumberMaxLength)]
        public string? PhoneNumber { get; set; }
    }
}
