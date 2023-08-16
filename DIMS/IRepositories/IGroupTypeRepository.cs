using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IGroupTypeRepository
    {
        Task<int> AddNewGroupTypeAsync(GroupType groupType);
        Task<List<GroupType>> GetAllGroupTypeAsync();
        Task<int> CheckGroupTypeDuplication(GroupType groupType);
    }
}
