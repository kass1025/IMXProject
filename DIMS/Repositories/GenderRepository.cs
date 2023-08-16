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
    public class GenderRepository : IGenderRepository
    {
        private readonly DIMSDbContext _dbContext;
        public GenderRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To get All Region data
        public async Task<List<Gender>> GetAllGenderAsync()
        {
            return await _dbContext.Genders.ToListAsync();
        }

        //To add Region 
        public async Task<int> AddNewGenderAsync(Gender gender)
        {
            var NewGender = new Gender()
            {
                GenderName = gender.GenderName,
                Description = gender.Description,
            };
            await _dbContext.Genders.AddAsync(NewGender);
            await _dbContext.SaveChangesAsync();
            return NewGender.Id;

        }

        //To check uplication
        public async Task<int> CheckGenderDuplication(Gender gender)
        {
            List<Gender> _titles = await (from m in _dbContext.Genders
                                                          where m.GenderName == gender.GenderName
                                                          select m).ToListAsync();
            return _titles.Count;
        }

    }
}
