using DIMS.DIMSDataContext;
using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DIMSDbContext _dbContext;
        public BranchRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewBranchAsync(Branch branch)
        {
            var NewBranch = new Branch()
            {
                BranchName = branch.BranchName,
                Description = branch.Description,
            };
            await _dbContext.Branches.AddAsync(NewBranch);
            await _dbContext.SaveChangesAsync();
            return NewBranch.Id;
        }

        public async Task<List<Branch>> GetAllBranchAsync()
        {
            return await _dbContext.Branches.ToListAsync();
        }

        public async Task<int> CheckBranchDuplication(Branch branch)
        {
            List<Branch> _branches = await (from m in _dbContext.Branches
                                                                where m.BranchName == branch.BranchName
                                                                select m).ToListAsync();
            return _branches.Count;
        }
    }
}
