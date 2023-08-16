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
    public class EducationInformationRepository : IEducationInformationRepository
    {
        private readonly DIMSDbContext _dbContext = null;
        public EducationInformationRepository(DIMSDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<IEnumerable<EducationInformation>> GetAllEducationInformationAsync()
        {
            return await _dbContext.EducationInformation.Include(x=>x.EducationLevel).Include(x=>x.EducationType).Include(x=>x.Member).ToListAsync();
        }
        public async Task<int> AddNewEducationInformationAsync(EducationInformation educationInformation)
        {
            var newEducationInformation = new EducationInformation()
            {
                InstitutionName = educationInformation.InstitutionName,              
                MemberId = educationInformation.MemberId,
                EducationLevelId = educationInformation.EducationLevelId,
                EducationTypeId= educationInformation.EducationTypeId,
                Certificate = educationInformation.Certificate,
            };
            await _dbContext.EducationInformation.AddAsync(newEducationInformation);
            await _dbContext.SaveChangesAsync();
            return newEducationInformation.Id;
        }

        public async Task<int> CheckEducationInformationDuplication(EducationInformation educationInformation)
        {
            List<EducationInformation> _educationInformation  = await (from m in _dbContext.EducationInformation
                                       //where m.CityName == city.CityName || m.CityCode== city.CityCode
                                       select m
                                       ).ToListAsync();
            return _educationInformation.Count();

        }
    }
}
