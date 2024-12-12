using PetPals.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Services.Data.Interfaces
{
    public interface IWishlistService
    {

        Task AddToWishlistAsync(Guid userId, Guid petId);


        Task<IEnumerable<Pet>> GetWishlistAsync(Guid userId);

        Task RemoveFromWishlistAsync(Guid userId, Guid petId);
    }
}
