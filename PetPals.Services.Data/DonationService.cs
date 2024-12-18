

using Microsoft.EntityFrameworkCore;
using PetPals.Data;
using PetPals.Data.Models;
using PetPals.Services.Data.Interfaces;

namespace PetPals.Services.Data
{
    public class DonationService : IDonationService
    {
        private readonly PetPalsDbContext dbContext;

        public DonationService(PetPalsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddDonationAsync(Donation donation)
        {
            await dbContext.Donations.AddAsync(donation);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Donation>> GetAllDonationsAsync()
        {
            return await dbContext.Donations.ToListAsync();
        }
    }

}
