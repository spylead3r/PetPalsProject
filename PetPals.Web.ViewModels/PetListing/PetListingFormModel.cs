using System.ComponentModel.DataAnnotations;

public class PetListingFormViewModel
{
    [Required]
    public string PetType { get; set; }

    [Required]
    public bool IsNeutered { get; set; }

    [Required]
    public string ReasonForRehoming { get; set; }

    [Required]
    public string AvailableCarePeriod { get; set; }

    public bool ShotsUpToDate { get; set; }
    public bool IsHouseTrained { get; set; }

    [Required]
    public string PetStory { get; set; }
}
