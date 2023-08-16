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
    public class EducationTypeRepository : IEducationTypeRepository
    {
        private readonly DIMSDbContext _dbContext;
        public EducationTypeRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<int> AddNewEducationTypeAsync(EducationType educationType)
        {
            var NewEducationTye = new EducationType()
            {
                TypeName = educationType.TypeName,
                Description = educationType.Description,
            };
            await _dbContext.EducationTypes.AddAsync(NewEducationTye);
            await _dbContext.SaveChangesAsync();
            return NewEducationTye.Id;
        }

        public async Task<List<EducationType>> GetAllEducationTypeAsync()
        {
            return await _dbContext.EducationTypes.ToListAsync();
        }

        public async Task<int> CheckEducationTypeDuplication(EducationType educationType)
        {
            List<EducationType> _educationTypes = await(from m in _dbContext.EducationTypes
                                        where m.TypeName == educationType.TypeName
                                        select m).ToListAsync();
            return _educationTypes.Count;
        }
    }
}
