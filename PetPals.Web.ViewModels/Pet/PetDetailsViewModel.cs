using Microsoft.AspNetCore.Http;
using PetPals.Data.Models;
using PetPals.Web.ViewModels.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Web.ViewModels.Pet
{
    public class PetDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string HealthStatus { get; set; }
        public string AdoptionStatus { get; set; }

        public decimal AdoptionFee { get; set; }

        public string PhotoPath { get; set; } // To hold the first photo's path or a default

        public List<PhotoViewModel> Photos { get; set; } = new();

        // For uploading photos (if needed in forms)
        public List<IFormFile> UploadPhotos { get; set; } = new();
    }
}
