using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Web.ViewModels.PetListing
{
    using System.ComponentModel.DataAnnotations;

    namespace PetPals.Web.ViewModels
    {
        public class PetListingCreateModel
        {
            [Required(ErrorMessage = "Pet type is required.")]
            [Display(Name = "Pet Type")]
            public string PetType { get; set; }

            [Required(ErrorMessage = "Please specify if the pet is neutered.")]
            [Display(Name = "Is Neutered")]
            public bool IsNeutered { get; set; }

            [Required(ErrorMessage = "Reason for rehoming is required.")]
            [Display(Name = "Reason for Rehoming")]
            public string ReasonForRehoming { get; set; }

            [Required(ErrorMessage = "Available care period is required.")]
            [Display(Name = "Available Care Period")]
            public string AvailableCarePeriod { get; set; }

            [Required(ErrorMessage = "Pet story is required.")]
            [Display(Name = "Pet's Story")]
            public string PetStory { get; set; }
        }
    }

}
