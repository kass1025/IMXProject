using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface ICapitalSourceRepository
    {
        Task<int> AddNewCapitalSourceAsync(CapitalSource  capitalSource);
        Task<List<CapitalSource>> GetAllCapitalSourceAsync();
        Task<int> CheckCapitalSourceDuplication(CapitalSource  capitalSource); 
    }
}
