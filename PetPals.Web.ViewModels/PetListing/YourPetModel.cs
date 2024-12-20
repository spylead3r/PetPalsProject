using System.ComponentModel.DataAnnotations;

public class YourPetModel
{
    // Data from Step 1
    public string PetType { get; set; }
    public string ReasonForRehoming { get; set; }
    public string AvailableCarePeriod { get; set; }
    public string PetStory { get; set; }

    // Data from Step 2
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    // Additional fields for Step 3
    [Required(ErrorMessage = "Please specify if the pet's shots are up-to-date.")]
    public bool ShotsUpToDate { get; set; }

    [Required(ErrorMessage = "Please specify if the pet is house-trained.")]
    public bool IsHouseTrained { get; set; }
}
