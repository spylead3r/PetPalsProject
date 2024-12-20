using PetPals.Data.Models;
using PetPals.Web.ViewModels.PetListing;


namespace PetPals.Services.Data.Interfaces
{
    public interface IPetListingService
    {
        Task CreateListingAsync(PetListingModel model, Guid userId);
        Task<List<PetListingModel>> GetAllListingsAsync();

        Task<PetListing> GetListingByIdAsync(Guid id);
        Task ApproveListingAsync(Guid id, string adminComments);
        Task RejectListingAsync(Guid id, string adminComments);

        Task<List<PetListing>> GetPendingListingsAsync();

        Task ApproveListingAndAddPetAsync(Guid id, string adminComments);


    }

}
