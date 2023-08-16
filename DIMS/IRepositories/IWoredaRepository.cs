using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IWoredaRepository
    {
        Task<int> AddNewWoredaAsync(Woreda zone);
        Task<IEnumerable<Woreda>> GetWoredasAsync();
        Task<int> CheckWoredaDuplication(Woreda woreda); 


    }
}
