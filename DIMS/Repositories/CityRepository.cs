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
    public class CityRepository : ICityRepository
    {
        private readonly DIMSDbContext _dbContext = null;
        public CityRepository(DIMSDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _dbContext.Cities.Include(x=>x.Woreda).Include(x=>x.Zone).ToListAsync();
        }
        public async Task<int> AddNewCityAsync(City city)
        {
            var newCity = new City()
            {
                CityName = city.CityName,
                CityCode = city.CityCode,
                Description = city.Description,
                ZoneId = city.ZoneId,
                WoredaId= city.WoredaId
            };
            await _dbContext.Cities.AddAsync(newCity);
            await _dbContext.SaveChangesAsync();
            return newCity.Id;
        }

        public async Task<int> CheckCityDuplication(City city)
        {
            List<City> _cities  = await (from m in _dbContext.Cities
                                       where m.CityName == city.CityName || m.CityCode== city.CityCode
                                       select m
                                       ).ToListAsync();
            return _cities.Count();

        }
    }
}
