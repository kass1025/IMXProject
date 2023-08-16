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
    public class EnterpriseAddressInfoRepository : IEnterpriseAddressInfoRepository
    {
        private readonly DIMSDbContext _dbContext = null;
        public EnterpriseAddressInfoRepository(DIMSDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<IEnumerable<EnterpriseAddressInfo>> GetAllEnterpriseAddressInfoAsync()
        {
            return await _dbContext.EnterpriseAddressInfos
                                   .Include(x=>x.Region)
                                   .Include(x=>x.Zone)
                                   .Include(x=>x.Woreda)
                                   .Include(x=>x.City)
                                   .Include(x=>x.Enterprise)
                                   .ToListAsync();
        }
        public async Task<int> AddNewEnterpriseAddressInfoAsync(EnterpriseAddressInfo enterpriseAddress)
        {
            var newEnterpriseAddressInfo = new EnterpriseAddressInfo()
            {
                RegionId = enterpriseAddress.RegionId,
                ZoneId = enterpriseAddress.ZoneId,
                WoredaId = enterpriseAddress.WoredaId,
                CityId = enterpriseAddress.CityId,
                EnterpriseId = enterpriseAddress.EnterpriseId,
                PhoneNumber= enterpriseAddress.PhoneNumber,
                HouseNumber = enterpriseAddress.HouseNumber,
                KebeleName = enterpriseAddress.KebeleName,
                EnterpriseAddress = enterpriseAddress.EnterpriseAddress,
            };
            await _dbContext.EnterpriseAddressInfos.AddAsync(newEnterpriseAddressInfo);
            await _dbContext.SaveChangesAsync();
            return newEnterpriseAddressInfo.Id;
        }

        public async Task<int> CheckEnterpriseAddressInfoDuplication(EnterpriseAddressInfo enterpriseAddress)
        {
            List<EnterpriseAddressInfo> _enterpriseAddresses  = await (from m in _dbContext.EnterpriseAddressInfos
                                       where m.PhoneNumber == enterpriseAddress.PhoneNumber || m.HouseNumber== enterpriseAddress.HouseNumber
                                       select m
                                       ).ToListAsync();
            if(enterpriseAddress.HouseNumber==null)
            {
                return 0;
            }
            return _enterpriseAddresses.Count();

        }
    }
}
