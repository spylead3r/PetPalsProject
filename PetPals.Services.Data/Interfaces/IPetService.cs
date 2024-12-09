using PetPals.Data.Models;

namespace PetPals.Services.Data.Interfaces
{
    public interface IPetService
    {
        Task AddPetAsync(PetFormModel formModel);
        Task<List<Pet>> GetAllPetsAsync();
        Task DeletePetAsync(Guid id);
    }
}
