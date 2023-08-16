using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IDisabilityRepository
    {
        Task<int> AddNewDisabilityAsync(Disability disability);
        Task<List<Disability>> GetAllDisabilityAsync();
        Task<int> CheckDisabilityDuplication(Disability disability); 
    }
}
