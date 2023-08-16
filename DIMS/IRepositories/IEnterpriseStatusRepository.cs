using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IEnterpriseStatusRepository
    {
        Task<int> AddNewEnterpriseStatusAsync(EnterpriseStatus enterpriseStatus);
        Task<List<EnterpriseStatus>> GetAllEnterpriseStatusAsync();
        Task<int> CheckEnterpriseStatusDuplication(EnterpriseStatus enterpriseStatus);
    }
}
