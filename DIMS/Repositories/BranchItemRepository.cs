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
    public class BranchItemRepository : IBranchItemRepository
    {
        private readonly DIMSDbContext _dbContext = null;
        public BranchItemRepository(DIMSDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<IEnumerable<BranchItem>> GetBranchItemAsync()
        {
            return await _dbContext.BranchItems.Include(x=>x.Branch).ToListAsync();
        }
        public async Task<int> AddNewBranchItemAsync(BranchItem branchItem)
        {
            var newBranchItem = new BranchItem()
            {
                BranchItemName = branchItem.BranchItemName,
                BranchId = branchItem.BranchId,
                Description = branchItem.Description,               
            };
            await _dbContext.BranchItems.AddAsync(newBranchItem);
            await _dbContext.SaveChangesAsync();
            return newBranchItem.Id;
        }

        public async Task<int> CheckBranchItemDuplication(BranchItem branchItem)
        {
            List<BranchItem> _branchItems = await (from m in _dbContext.BranchItems
                                       where m.BranchItemName == branchItem.BranchItemName                                       select m
                                       ).ToListAsync();
            return _branchItems.Count();

        }
    }
}
