using System.ComponentModel.DataAnnotations;

public class PetListingAboutYouModel
{
    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number.")]
    public string PhoneNumber { get; set; }

    // Step 1 data (for reference or pre-filling)
    public string PetType { get; set; }
    public bool? IsNeutered { get; set; }
    public string ReasonForRehoming { get; set; }
    public string AvailableCarePeriod { get; set; }
    public string PetStory { get; set; }
}
