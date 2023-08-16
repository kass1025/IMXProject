using System.Collections.Generic;
using System.Threading.Tasks;
using DIMS.Entities;
using DIMS.Entities.Account;

namespace DIMS.IRepositories
{
    public interface IApplicationUsersRepository
    {
        Task<IEnumerable<ApplicationUsers>> GetAllApplicationUsers();
    }
}