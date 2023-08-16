using DIMS.Entities.Account;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIMS.Entities;
using DIMS.ViewModel;

namespace DIMS.IRepositories
{
    public interface IAccountRepository
    {
        //Task<ApplicationUsers> ChangeUserPasswordAsync(string id, string password);
        //Task<ApplicationUsers> APProveUseAsync(string id, string approvedBy);
        Task<IdentityResult> CreateUserAsync(AccountRegistrationViewModel accountRegistration );      
        Task<IEnumerable<ApplicationUsers>> GetAllUsersAsync();
        //Task<ApplicationUsers> RemoveAccountAsync(string id);
        //Task<IEnumerable<ApplicationUsers>> GetAllUsersByRoleAsync();
        Task<IEnumerable<ApplicationUsers>> GetAllUsersByIdAsync(string id);
        Task<SignInResult> SignInAsync(UserLoginViewModel loginViewModel);
        Task SignOutAsync();
        Task<int> CheckUserAccountItemDuplication(AccountRegistrationViewModel account);
    }
}