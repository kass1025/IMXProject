using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIMS.Entities;
using DIMS.IRepositories;
using DIMS.DIMSDataContext;
using DIMS.Entities.Account;

namespace DIMS.Repositories
{
    public class ApplicationUsersRepository : IApplicationUsersRepository
    {
        private readonly DIMSDbContext _dbContext = null;

        public ApplicationUsersRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ApplicationUsers>> GetAllApplicationUsers()
        {
            return await _dbContext.ApplicationUsers.Include(x=>x.UserLocations).ToListAsync();
        }
    }
}
