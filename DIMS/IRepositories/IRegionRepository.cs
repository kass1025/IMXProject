using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IRegionRepository
    {
        Task<int> AddNewRegionAsync(Region region);
        Task<List<Region>> GetAllRegionAsync();
        Task<int> RegionNameDuplicationCheck(Region region);
    }
}
