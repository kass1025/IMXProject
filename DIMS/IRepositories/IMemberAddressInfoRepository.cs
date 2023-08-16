using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IMemberAddressInfoRepository
    {
        Task<int> AddNewMemberAddressInfoAsync(MemberAddressInfo  memberAddressInfo); 
        Task<IEnumerable<MemberAddressInfo>> GetAllMemberAddressInfoAsync();
        Task<int> CheckMemberAddressInfoDuplication(MemberAddressInfo memberAddressInfo ); 


    }
}
