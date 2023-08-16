using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IBranchRepository
    {
        Task<int> AddNewBranchAsync(Branch branch);
        Task<List<Branch>> GetAllBranchAsync();
        Task<int> CheckBranchDuplication(Branch branch); 
    }
}
