using Microsoft.EntityFrameworkCore;
using PetPals.Data;
using PetPals.Data.Models;
using PetPals.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Services.Data
{
    public class WishlistService : IWishlistService
    {
        private readonly PetPalsDbContext dbContext;

        public WishlistService(PetPalsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddToWishlistAsync(Guid userId, Guid petId)
        {
            var exists = await dbContext.Wishlists
                .AnyAsync(w => w.UserId == userId && w.PetId == petId);

            if (!exists)
            {
                var wishlistItem = new Wishlist
                {
                    UserId = userId,
                    PetId = petId
                };

                dbContext.Wishlists.Add(wishlistItem);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Pet>> GetWishlistAsync(Guid userId)
        {
            return await dbContext.Wishlists
                .Where(w => w.UserId == userId)
                .Select(w => w.Pet)
                .ToListAsync();
        }

        public async Task RemoveFromWishlistAsync(Guid userId, Guid petId)
        {
            var wishlistItem = await dbContext.Wishlists
                .FirstOrDefaultAsync(w => w.UserId == userId && w.PetId == petId);

            if (wishlistItem != null)
            {
                dbContext.Wishlists.Remove(wishlistItem);
                await dbContext.SaveChangesAsync();
            }
        }
    }

}
