using System.ComponentModel.DataAnnotations;
using PetPals.Common;

namespace PetPals.Data.Models
{
    using static EntityValidationConstants.Pet;
    public class Pet
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(SpeciesMaxLength)]
        public string Species { get; set; } = null!;

        [MaxLength(BreedMaxLength)]
        public string Breed { get; set; } = null!;


        [Required]
        [Range(AgeMinValue, AgeMaxValue)]
        public int Age { get; set; } 

        [Required]
        public string HealthStatus { get; set; } = null!;

        [Required]
        public string AdoptionStatus { get; set; } = null!;

        public decimal AdoptionFee { get; set; }


        public virtual ICollection<ApplicationUserPet> UserPets { get; set; } = new HashSet<ApplicationUserPet>();


        [Required]
        public virtual ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();


    }
}
