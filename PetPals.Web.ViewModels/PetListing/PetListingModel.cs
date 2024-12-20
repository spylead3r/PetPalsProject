using System;
using System.ComponentModel.DataAnnotations;

namespace PetPals.Web.ViewModels.PetListing
{
    public class PetListingModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Pet Type")]
        public string PetType { get; set; }

        [Display(Name = "Is Neutered")]
        public bool IsNeutered { get; set; }

        [Display(Name = "Reason for Rehoming")]
        public string ReasonForRehoming { get; set; }

        [Display(Name = "Available Care Period")]
        public string AvailableCarePeriod { get; set; }

        // User Details
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        // Pet Characteristics
        [Display(Name = "Pet Name")]
        public string PetName { get; set; }

        [Display(Name = "Shots Up-to-Date")]
        public bool ShotsUpToDate { get; set; }

        [Display(Name = "House Trained")]
        public bool IsHouseTrained { get; set; }

        [Display(Name = "Pet's Story")]
        public string PetStory { get; set; }

        // Admin Review
        [Display(Name = "Is Approved")]
        public bool IsApproved { get; set; }

        [Display(Name = "Is Rejected")]
        public bool IsRejected { get; set; }

        [Display(Name = "Admin Comments")]
        public string AdminComments { get; set; }
    }
}
