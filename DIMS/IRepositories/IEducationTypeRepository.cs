using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IEducationTypeRepository
    {
        Task<int> AddNewEducationTypeAsync(EducationType educationType);
        Task<List<EducationType>> GetAllEducationTypeAsync();
        Task<int> CheckEducationTypeDuplication(EducationType educationType); 
    }
}
