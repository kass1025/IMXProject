using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IEnterpriseLevelRepository
    {
        Task<int> AddNewEnterpriseLevelAsync(EnterpriseLevel enterpriseLevel);
        Task<List<EnterpriseLevel>> GetAllEnterpriseLevelAsync();
        Task<int> CheckEnterpriseLevelDuplication(EnterpriseLevel enterpriseLevel);
    }
}
