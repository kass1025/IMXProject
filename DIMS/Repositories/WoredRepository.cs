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
    public class WoredaRepository : IWoredaRepository
    {
        private readonly DIMSDbContext _dbContext = null;
        public WoredaRepository(DIMSDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<IEnumerable<Woreda>> GetWoredasAsync()
        {
            return await _dbContext.Woredas.Include(x=>x.Zone).Include(x=>x.Cities).ToListAsync();
        }
        public async Task<int> AddNewWoredaAsync(Woreda woreda)
        {
            var newWoreda = new Woreda()
            {
                WoredaName = woreda.WoredaName,
                WoredaCode = woreda.WoredaCode,
                Description = woreda.Description,
                ZoneId = woreda.ZoneId,
            };
            await _dbContext.Woredas.AddAsync(newWoreda);
            await _dbContext.SaveChangesAsync();
            return newWoreda.Id;
        }

        public async Task<int> CheckWoredaDuplication(Woreda woreda)
        {
            List<Woreda> _woredas = await (from m in _dbContext.Woredas
                                       where m.WoredaName == woreda.WoredaName || m.WoredaCode== woreda.WoredaCode
                                       select m
                                       ).ToListAsync();
            return _woredas.Count();

        }
    }
}
