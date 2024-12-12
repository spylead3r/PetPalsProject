using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Data.Models
{
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; } // FK for ApplicationUser

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }


        [Required]
        public Guid PetId { get; set; } // FK for Pet

        [ForeignKey(nameof(PetId))]
        public virtual Pet Pet { get; set; }
    }

}
