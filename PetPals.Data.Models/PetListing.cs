using System.ComponentModel.DataAnnotations;

namespace PetPals.Data.Models
{
    public class PetListing
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        public string PetType { get; set; }

        [Required]
        public bool IsNeutered { get; set; }

        [Required]
        public string ReasonForRehoming { get; set; }

        [Required]
        public string AvailableCarePeriod { get; set; }

        // User Details
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } // Navigation property to the Pet entity

        // Pet Characteristics
        public Guid PetId { get; set; }
        public Pet Pet { get; set; } // Navigation property to the Pet entity



        public bool ShotsUpToDate { get; set; }

        public bool IsHouseTrained { get; set; }

        public string PetStory { get; set; }

        // Admin Review
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public string AdminComments { get; set; }
    }
}
