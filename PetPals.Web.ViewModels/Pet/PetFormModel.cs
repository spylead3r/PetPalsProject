using System.ComponentModel.DataAnnotations;
using static PetPals.Common.EntityValidationConstants.Pet;

public class PetFormModel
{
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; }

    [Required]
    [MaxLength(SpeciesMaxLength)]
    public string Species { get; set; }

    [MaxLength(BreedMaxLength)]
    public string Breed { get; set; }

    [Range(AgeMinValue, AgeMaxValue)]
    public int Age { get; set; }

    [Required]
    public string HealthStatus { get; set; }

    [Required]
    public string AdoptionStatus { get; set; }

    public string PhotoPath { get; set; }
}

