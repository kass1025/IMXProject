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
    public class EnterpriseStatusRepository : IEnterpriseStatusRepository
    {
        private readonly DIMSDbContext _dbContext;
        public EnterpriseStatusRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewEnterpriseStatusAsync(EnterpriseStatus enterpriseStatus)
        {
            var NewEnterpriseStatus = new EnterpriseStatus()
            {
                EnterpriseStatusName = enterpriseStatus.EnterpriseStatusName,
                Description = enterpriseStatus.Description,
            };
            await _dbContext.EnterpriseStatuses.AddAsync(NewEnterpriseStatus);
            await _dbContext.SaveChangesAsync();
            return NewEnterpriseStatus.Id;
        }

        public async Task<List<EnterpriseStatus>> GetAllEnterpriseStatusAsync()
        {
            return await _dbContext.EnterpriseStatuses.ToListAsync();
        }

        public async Task<int> CheckEnterpriseStatusDuplication(EnterpriseStatus enterpriseStatus)
        {
            List<EnterpriseStatus> _enterpriseStatuses = await (from m in _dbContext.EnterpriseStatuses
                                                              where m.EnterpriseStatusName == enterpriseStatus.EnterpriseStatusName
                                                             select m).ToListAsync();
            return _enterpriseStatuses.Count;
        }
    }
}
