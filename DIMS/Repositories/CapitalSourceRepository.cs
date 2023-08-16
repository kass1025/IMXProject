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
    public class CapitalSourceRepository : ICapitalSourceRepository
    {
        private readonly DIMSDbContext _dbContext;
        public CapitalSourceRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewCapitalSourceAsync(CapitalSource capitalSource)
        {
            var NewCapitalSource = new CapitalSource()
            {
                CapitalSourceName = capitalSource.CapitalSourceName,                
                Description = capitalSource.Description,
            };
            await _dbContext.CapitalSources.AddAsync(NewCapitalSource);
            await _dbContext.SaveChangesAsync();
            return NewCapitalSource.Id;
        }

        public async Task<List<CapitalSource>> GetAllCapitalSourceAsync()
        {
            return await _dbContext.CapitalSources.ToListAsync();
        }

        public async Task<int> CheckCapitalSourceDuplication(CapitalSource capitalSource)
        {
            List<CapitalSource> _capitalSources = await (from m in _dbContext.CapitalSources
                                                                where m.CapitalSourceName == capitalSource.CapitalSourceName
                                                                select m).ToListAsync();
            return _capitalSources.Count;
        }
    }
}
