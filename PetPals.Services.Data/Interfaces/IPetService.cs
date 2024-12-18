using Microsoft.AspNetCore.Http;
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

        Task<PetDetailsViewModel?> GetPetDetailsAsync(Guid id);

        Task<IEnumerable<Pet>> GetCatsAsync();

        Task<IEnumerable<PetIndexViewModel>> GetAllPetsWithPhotoAsync();

        Task<bool> UpdatePetPhotosAsync(Guid petId, List<IFormFile> files);

        Task<Guid?> DeletePhotoAsync(Guid photoId);

        Task<bool> AddPetPhotosAsync(Guid petId, List<IFormFile> files);

        Task<bool> UpdatePetWithPhotosAsync(Guid id, PetFormModel model);




    }
}
