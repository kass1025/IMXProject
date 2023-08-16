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
    public class EducationLevelRepository : IEducationLevelRepository
    {
        private readonly DIMSDbContext _dbContext;
        public EducationLevelRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewEducationLevelAsync(EducationLevel educationLevel)
        {
            var NewEducationLevel = new EducationLevel()
            {
                LevelName = educationLevel.LevelName,
                Description = educationLevel.Description,
            };
            await _dbContext.EducationLevels.AddAsync(NewEducationLevel);
            await _dbContext.SaveChangesAsync();
            return NewEducationLevel.Id;
        }

        public async Task<List<EducationLevel>> GetAllEducationLevelAsync()
        {
            return await _dbContext.EducationLevels.ToListAsync();
        }

        public async Task<int> CheckEducationLevelDuplication(EducationLevel educationLevel)
        {
            List<EducationLevel> _educationLevels = await (from m in _dbContext.EducationLevels
                                                         where m.LevelName == educationLevel.LevelName
                                                         select m).ToListAsync();
            return _educationLevels.Count;
        }
    }
}
