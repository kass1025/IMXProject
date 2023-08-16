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
    public class RegionRepository : IRegionRepository
    {
        private readonly DIMSDbContext _dbContext;
        public RegionRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To get All Region data
        public async Task<List<Region>> GetAllRegionAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        //To add Region 
        public async Task<int> AddNewRegionAsync(Region region)
        {
            var NewRegion = new Region()
            {
                RegionName = region.RegionName,
                RegionCode = region.RegionCode,
                Description = region.Description,
            };
            await _dbContext.Regions.AddAsync(NewRegion);
            await _dbContext.SaveChangesAsync();
            return NewRegion.Id;

        }

        //To check uplication
        public async Task<int> RegionNameDuplicationCheck(Region region)
        {
            List<Region> _regions = await (from m in _dbContext.Regions
                                                          where m.RegionName == region.RegionName || m.RegionCode==region.RegionCode
                                                          select m).ToListAsync();
            return _regions.Count;
        }

    }
}
