using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IBranchItemRepository
    {
        Task<int> AddNewBranchItemAsync(BranchItem branchItem );
        Task<IEnumerable<BranchItem>> GetBranchItemAsync();
        Task<int> CheckBranchItemDuplication(BranchItem branchItem);


    }
}
