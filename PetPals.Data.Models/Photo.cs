using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Data.Models
{
    public class Photo
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid PetId { get; set; }

        [Required]
        public string PhotoPath { get; set; } = null!;

        // Navigation Property
        public virtual Pet Pet { get; set; } = null!;

    }
}
