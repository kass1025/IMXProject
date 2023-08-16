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
    public class TitleRepository : ITitleRepository
    {
        private readonly DIMSDbContext _dbContext;
        public TitleRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To get All Region data
        public async Task<List<Title>> GetAllTitleAsync()
        {
            return await _dbContext.Titles.ToListAsync();
        }

        //To add Region 
        public async Task<int> AddNewTitleAsync(Title title)
        {
            var NewTitle = new Title()
            {
                TitleName = title.TitleName,
                Description = title.Description,
            };
            await _dbContext.Titles.AddAsync(NewTitle);
            await _dbContext.SaveChangesAsync();
            return NewTitle.Id;

        }

        //To check uplication
        public async Task<int> CheckTitleDuplication(Title title)
        {
            List<Title> _titles = await (from m in _dbContext.Titles
                                                          where m.TitleName == title.TitleName
                                                          select m).ToListAsync();
            return _titles.Count;
        }

    }
}
