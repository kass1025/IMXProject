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
    public class DisabilityRepository : IDisabilityRepository
    {
        private readonly DIMSDbContext _dbContext;
        public DisabilityRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        //To add Region          

        public async Task<int> AddNewDisabilityAsync(Disability disability)
        {
            var NewDisability = new Disability()
            {
                DisabilityName = disability.DisabilityName,
                Description = disability.Description,
            };
            await _dbContext.Disabilities.AddAsync(NewDisability);
            await _dbContext.SaveChangesAsync();
            return NewDisability.Id;
        }

        //To get All Region data

        public async Task<List<Disability>> GetAllDisabilityAsync()
        {
            return await _dbContext.Disabilities.ToListAsync();
        }

        //To check uplication
        public async Task<int> CheckDisabilityDuplication(Disability disability)
        {
            List<Disability> _titles = await(from m in _dbContext.Disabilities
                                        where m.DisabilityName == disability.DisabilityName
                                        select m).ToListAsync();
            return _titles.Count;
        }
    }
}
