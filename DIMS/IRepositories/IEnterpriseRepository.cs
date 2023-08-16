using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IEnterpriseRepository
    {
        Task<int> AddNewEnterpriseAsync(Enterprise enterprise, int EnterPriseLocationId); 
        Task<IEnumerable<Enterprise>> GetAllEnterpriseAsync(); 
        Task<int> CheckEnterpriseDuplication(Enterprise enterprise);
        Task<int> GetUserLocationIdAsync(int userLocationId);
    }
}
