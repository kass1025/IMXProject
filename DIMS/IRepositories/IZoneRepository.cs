using DIMS.Entities;
using DIMS.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IZoneRepository
    {
        Task<int> AddNewZoneAsync(Zone zone);
        Task<IEnumerable<Zone>> GetZonesAsync();
        Task<int> CheckZoneDuplication(Zone zone);
        Task<IEnumerable<ApplicationUsers>> GetAllUsersAsync();

    }
}
