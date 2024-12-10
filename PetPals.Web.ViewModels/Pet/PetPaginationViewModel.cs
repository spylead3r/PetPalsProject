using PetModel = PetPals.Data.Models.Pet;

namespace PetPals.Web.ViewModels.Pet
{
    public class PetPaginationViewModel
    {
        public IEnumerable<PetModel> Pets { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchQuery { get; set; }
    }
}
