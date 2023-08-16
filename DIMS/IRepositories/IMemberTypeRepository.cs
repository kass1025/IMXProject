using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IMemberTypeRepository
    {
        Task<int> AddNewMemberTypeAsync(MemberType memberType);
        Task<List<MemberType>> GetAllMemberTypeAsync();
        Task<int> CheckMemberTypeDuplication(MemberType memberType);
    }
}
