using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Data.Models
{
    public class ApplicationUserPet
    {
        public Guid ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid PetId { get; set; }

        public virtual Pet Pet { get; set; } = null!;
    }
}
