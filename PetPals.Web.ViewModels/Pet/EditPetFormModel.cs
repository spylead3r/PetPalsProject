using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Web.ViewModels.Pet
{
    public class EditPetFormModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string HealthStatus { get; set; } = null!;
        public string AdoptionStatus { get; set; } = null!;

        public List<IFormFile> Photos { get; set; } = new();
    }
}
