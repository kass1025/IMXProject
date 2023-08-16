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
    public class PromotionLevelRepository : IPromotionLevelRepository
    {
        private readonly DIMSDbContext _dbContext;
        public PromotionLevelRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewPromotionLevelAsync(PromotionLevel promotionLevel)
        {
            var NewPromotionLevel = new PromotionLevel()
            {
                PromotionLeveName = promotionLevel.PromotionLeveName,
                Description = promotionLevel.Description,
            };
            await _dbContext.PromotionLevels.AddAsync(NewPromotionLevel);
            await _dbContext.SaveChangesAsync();
            return NewPromotionLevel.Id;
        }

        public async Task<List<PromotionLevel>> GetAllPromotionLevelAsync()
        {
            return await _dbContext.PromotionLevels.ToListAsync();
        }

        public async Task<int> CheckPromotionLevelDuplication(PromotionLevel promotionLevel)
        {
            List<PromotionLevel> _promotionLevels = await (from m in _dbContext.PromotionLevels
                                                   where m.PromotionLeveName == promotionLevel.PromotionLeveName
                                                   select m).ToListAsync();
            return _promotionLevels.Count;
        }
    }
}
