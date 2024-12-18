using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Web.ViewModels.Pet
{
    public class PetListingModel
    {
        // Step 1: Start
        public string PetType { get; set; } // e.g., Dog, Cat
        public string IsSpayedOrNeutered { get; set; }
        public string ReasonForRehoming { get; set; }
        public string DurationToKeepPet { get; set; }

        // Step 2: About You
        public string OwnerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Step 3: Your Pet Details
        public string PetName { get; set; }
        public int PetAge { get; set; }
        public string PetBreed { get; set; }
        public IFormFileCollection Photos { get; set; } // Upload pet photos

        // Step 4: Confirmation
        public bool TermsAgreed { get; set; }
    }
}
