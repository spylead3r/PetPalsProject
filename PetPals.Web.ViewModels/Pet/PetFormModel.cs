using Microsoft.AspNetCore.Http;
using PetPals.Data.Models;
using System.ComponentModel.DataAnnotations;
using static PetPals.Common.EntityValidationConstants.Pet;

public class PetFormModel
{
    public Guid Id { get; set; } // Add this if missing

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

    [Required]
    public decimal AdoptionFee { get; set; }


    [Required]

    public List<IFormFile>? Photos { get; set; } = new List<IFormFile>();

    public List<Photo> ExistingPhotos { get; set; } = new();

}

