
namespace PetPals.Web.ViewModels.Pet
{
    public class PetIndexViewModel
    {
        public Guid Id { get; set; }  // Pet Id
        public string Name { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public int Age { get; set; }
        public string AdoptionStatus { get; set; } = null!;

        // Single Photo for the Index Page
        public string? PhotoPath { get; set; }
    }
}
