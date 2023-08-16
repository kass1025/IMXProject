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
    public class EnterpriseLevelRepository : IEnterpriseLevelRepository
    {
        private readonly DIMSDbContext _dbContext;
        public EnterpriseLevelRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<int> AddNewEnterpriseLevelAsync(EnterpriseLevel enterpriseLevel)
        {
            var NewEnterpriseLevel = new EnterpriseLevel()
            {
                EnterpriseLevelName = enterpriseLevel.EnterpriseLevelName,
                Description = enterpriseLevel.Description,
            };
            await _dbContext.EnterpriseLevels.AddAsync(NewEnterpriseLevel);
            await _dbContext.SaveChangesAsync();
            return NewEnterpriseLevel.Id;
        }

        public async Task<List<EnterpriseLevel>> GetAllEnterpriseLevelAsync()
        {
            return await _dbContext.EnterpriseLevels.ToListAsync();
        }

        public async Task<int> CheckEnterpriseLevelDuplication(EnterpriseLevel enterpriseLevel)
        {
            List<EnterpriseLevel> _enterpriseLevels  = await (from m in _dbContext.EnterpriseLevels
                                                           where m.EnterpriseLevelName == enterpriseLevel.EnterpriseLevelName
                                                           select m).ToListAsync();
            return _enterpriseLevels.Count;
        }
    }
}
