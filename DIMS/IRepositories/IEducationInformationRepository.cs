using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IEducationInformationRepository
    {
        Task<int> AddNewEducationInformationAsync(EducationInformation educationInformation);
        Task<IEnumerable<EducationInformation>> GetAllEducationInformationAsync();
        Task<int> CheckEducationInformationDuplication(EducationInformation educationInformation);  


    }
}
