using Microsoft.AspNetCore.Http;
using PetPals.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Web.ViewModels.Event
{
    public class EventFormModel
    {
        [Required]
        [MaxLength(EntityValidationConstants.Event.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(EntityValidationConstants.Event.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(EntityValidationConstants.Event.LocationMaxLength)]
        public string Location { get; set; }

        public IFormFile Photo { get; set; } // File upload for the photo


        [Range(1, int.MaxValue, ErrorMessage = "Max Participants must be greater than zero.")]
        public int MaxParticipants { get; set; }
    }

}
