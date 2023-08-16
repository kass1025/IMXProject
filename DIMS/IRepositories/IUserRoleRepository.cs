using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIMS.Entities.Account;

namespace DIMS.IRepositories
{
    public interface IUserRoleRepository
    {
        Task<IdentityResult> CreateUserRoleAsync(UserRoles userRoles);
        Task<IEnumerable<IdentityRole>> GetAllUsersRoleAsync();
    }
}