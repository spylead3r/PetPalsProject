using PetPals.Common;
using System.ComponentModel.DataAnnotations;

namespace PetPals.Data.Models
{
    using static EntityValidationConstants.Volunteer;
    public class Volunteer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(ContactInfoMaxLength)]
        public string ContactInfo { get; set; } 

        public string Task { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
