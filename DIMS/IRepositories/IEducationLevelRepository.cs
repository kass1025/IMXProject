using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IEducationLevelRepository
    {
        Task<int> AddNewEducationLevelAsync(EducationLevel educationLevel);
        Task<List<EducationLevel>> GetAllEducationLevelAsync();
        Task<int> CheckEducationLevelDuplication(EducationLevel educationLevel); 
    }
}
