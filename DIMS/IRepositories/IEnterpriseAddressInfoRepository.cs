using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IEnterpriseAddressInfoRepository
    {
        Task<int> AddNewEnterpriseAddressInfoAsync(EnterpriseAddressInfo  enterpriseAddress); 
        Task<IEnumerable<EnterpriseAddressInfo>> GetAllEnterpriseAddressInfoAsync();
        Task<int> CheckEnterpriseAddressInfoDuplication(EnterpriseAddressInfo enterpriseAddress); 


    }
}
