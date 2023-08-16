using DIMS.DIMSDataContext;
using DIMS.Entities;
using DIMS.Entities.Account;
using DIMS.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly DIMSDbContext _dbContext = null;
        public EnterpriseRepository(DIMSDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<int> GetUserLocationIdAsync(int userLocationId)
        {
            return await _dbContext.UserLocations.Where(x=>x.UserLocationId==userLocationId).Select(x=>x.Id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Enterprise>> GetAllEnterpriseAsync()
        {
            return await _dbContext.Enterprises
                                   .Include(x=>x.CapitalSource)
                                   .Include(x=>x.GroupType)
                                   .Include(x=>x.BranchItem)
                                   .Include(x=>x.PromotionLevel)
                                   .Include(x=>x.EnterpriseLevel)
                                   .Include(x=>x.EnterpriseStatus)
                                   .ToListAsync();
        }
        public async Task<int> AddNewEnterpriseAsync(Enterprise enterprise, int EnterPriseLocationId)
        {
            var LocationId = await _dbContext.UserLocations.Where(x => x.UserLocationId == EnterPriseLocationId).Select(x=>x.Id).FirstOrDefaultAsync();
            var newEnterprise = new Enterprise()
            {
                EnterpriseName = enterprise.EnterpriseName,
                TINNumber = enterprise.TINNumber,
                InitialCapital = enterprise.InitialCapital,
                CurrentCapital = enterprise.CurrentCapital,
                FoundedYear = enterprise.FoundedYear,
                CapitalSourceId= enterprise.CapitalSourceId,
                GroupTypeId = enterprise.GroupTypeId,
                BranchItemId = enterprise.BranchItemId,
                PromotionLevelId = enterprise.PromotionLevelId,
                EnterpriseLevelId = enterprise.EnterpriseLevelId,
                EnterpriseStatusId = enterprise.EnterpriseStatusId,
                EnterUserLocationId = LocationId,
                MaleFouder= enterprise.MaleFouder,
                FemaleFounder = enterprise.FemaleFounder,
                MaleFouderYear =enterprise.MaleFouderYear,
                FemaleFounderYear = enterprise.FemaleFounderYear,
            };
            await _dbContext.Enterprises.AddAsync(newEnterprise);
            await _dbContext.SaveChangesAsync();
            return newEnterprise.Id;
        }

        public async Task<int> CheckEnterpriseDuplication(Enterprise enterprise)
        {

            List<Enterprise> _enterprises  = await (from m in _dbContext.Enterprises
                                       where m.EnterpriseName == enterprise.EnterpriseName || m.TINNumber== enterprise.TINNumber
                                       select m
                                       ).ToListAsync();
            if (enterprise.TINNumber == null)
            {
                return 0;
            }
            return _enterprises.Count();

        }
    }
}
