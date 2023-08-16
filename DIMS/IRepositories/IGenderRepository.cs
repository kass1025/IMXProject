using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IGenderRepository
    {
        Task<int> AddNewGenderAsync(Gender gender);
        Task<List<Gender>> GetAllGenderAsync();
        Task<int> CheckGenderDuplication(Gender gender); 
    }
}
