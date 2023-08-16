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
    public class MemberAddressInfoRepository : IMemberAddressInfoRepository
    {
        private readonly DIMSDbContext _dbContext = null;
        public MemberAddressInfoRepository(DIMSDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<IEnumerable<MemberAddressInfo>> GetAllMemberAddressInfoAsync()
        {
            return await _dbContext.MemberAddressInfos
                                   .Include(x=>x.Region)
                                   .Include(x=>x.Zone)
                                   .Include(x=>x.Woreda)
                                   .Include(x=>x.City)
                                   .Include(x=>x.Member.Enterprise)
                                   .ToListAsync();
        }
        public async Task<int> AddNewMemberAddressInfoAsync(MemberAddressInfo memberAddress )
        {
            var newMemberAddressInfo = new MemberAddressInfo()
            {
                RegionId = memberAddress.RegionId,
                ZoneId = memberAddress.ZoneId,
                WoredaId = memberAddress.WoredaId,
                CityId = memberAddress.CityId,
                MemberId = memberAddress.MemberId,
                KebeleName = memberAddress.KebeleName,
                MemberAddress = memberAddress.MemberAddress,
            };
            await _dbContext.MemberAddressInfos.AddAsync(newMemberAddressInfo);
            await _dbContext.SaveChangesAsync();
            return newMemberAddressInfo.Id;
        }

        public async Task<int> CheckMemberAddressInfoDuplication(MemberAddressInfo memberAddress)
        {
            List<MemberAddressInfo> _memberAddressInfos  = await (from m in _dbContext.MemberAddressInfos
                                       //where m.PhoneNumber == memberAddress.PhoneNumber || m.HouseNumber== enterpriseAddress.HouseNumber
                                       select m
                                       ).ToListAsync();
            return _memberAddressInfos.Count();

        }
    }
}
