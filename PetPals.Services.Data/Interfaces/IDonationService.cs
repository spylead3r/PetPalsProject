
using PetPals.Data.Models;

namespace PetPals.Services.Data.Interfaces
{
    public interface IDonationService
    {
        Task AddDonationAsync(Donation donation);


    }
}
