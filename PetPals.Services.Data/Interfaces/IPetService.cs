using PetPals.Data.Models;
using PetPals.Web.ViewModels.Pet;

namespace PetPals.Services.Data.Interfaces
{
    public interface IPetService
    {
        Task AddPetAsync(PetFormModel formModel);
        Task<List<Pet>> GetAllPetsAsync();

        Task<Pet?> GetPetByIdAsync(Guid id);

        Task DeletePetAsync(Guid id);
        Task<bool> UpdatePetAsync(Guid id, PetFormModel model);

        Task<int> GetTotalPetsCountAsync(string search);
    }
}
