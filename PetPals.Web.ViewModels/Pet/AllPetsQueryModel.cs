using PetModel = PetPals.Data.Models.Pet;

namespace PetPals.Web.ViewModels.Pet
{
    public class AllPetsQueryModel
    {
        public AllPetsQueryModel()
        {

        }

        public int CurrentPage { get; set; } = 1; // Current page
        public int PetsPerPage { get; set; } = 9; // 3x3 Grid = 9 pets
        public int TotalPets { get; set; } // Total pets count

        public string SearchInput { get; set; } = string.Empty; // Optional search input

        public List<PetModel> Pets { get; set; } = new List<PetModel>();


    }
}

