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
    public class ZoneRepository : IZoneRepository
    {
        private readonly DIMSDbContext _dbContext = null;
        public ZoneRepository(DIMSDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<IEnumerable<ApplicationUsers>> GetAllUsersAsync()
        {
            return await _dbContext.ApplicationUsers.Include(x => x.UserLocations).ToListAsync();
        }

        public async Task<IEnumerable<Zone>> GetZonesAsync()
        {
            return await _dbContext.Zones.Include(x=>x.Region).Include(x=>x.Woredas).Include(x=>x.Cities).ToListAsync();
        }
        public async Task<int> AddNewZoneAsync(Zone zone)
        {
            var newZone = new Zone()
            {
                ZoneName = zone.ZoneName,
                ZoneCode = zone.ZoneCode,
                Description = zone.Description,
                RegionId = zone.RegionId,
            };
            await _dbContext.Zones.AddAsync(newZone);
            await _dbContext.SaveChangesAsync();
            return newZone.Id;
        }

        public async Task<int> CheckZoneDuplication(Zone zone)
        {
            List<Zone> _zones = await (from m in _dbContext.Zones
                                       where m.ZoneName == zone.ZoneName || m.ZoneCode==zone.ZoneCode
                                       select m
                                       ).ToListAsync();
            return _zones.Count();

        }
    }
}
