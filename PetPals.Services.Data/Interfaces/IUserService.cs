using PetPals.Data.Models;
using PetPals.Web.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<bool> AssignUserToRoleAsync(Guid userId, string roleName);

        Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();

        Task<bool> UserExistsByIdAsync(Guid userId);

        Task<bool> RemoveUserRoleAsync(Guid userId, string roleName);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
