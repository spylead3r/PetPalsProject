
using System.ComponentModel.DataAnnotations;

namespace PetPals.Web.ViewModels.Volunteer
{
    public class VolunteerFormModel
    {
        public Guid Id { get; set; } // Add this property

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Contact information cannot exceed 100 characters.")]
        public string ContactInfo { get; set; }

        public string Task { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
