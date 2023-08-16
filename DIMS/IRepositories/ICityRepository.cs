using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface ICityRepository
    {
        Task<int> AddNewCityAsync(City city);
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<int> CheckCityDuplication(City city); 


    }
}
