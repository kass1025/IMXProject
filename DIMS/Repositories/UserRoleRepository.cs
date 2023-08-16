using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIMS.Entities.Account;
using DIMS.IRepositories;

namespace DIMS.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> CreateUserRoleAsync(UserRoles userRoles)
        {            
            var role = new IdentityRole()
            {
                Name = userRoles.RoleName,
                
            };
            var result = await _roleManager.CreateAsync(role);
            return result;

        }
       
        public async Task<IEnumerable<IdentityRole>> GetAllUsersRoleAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }
    }
}
