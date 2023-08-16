using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IPromotionLevelRepository
    {
        Task<int> AddNewPromotionLevelAsync(PromotionLevel promotionLevel);
        Task<List<PromotionLevel>> GetAllPromotionLevelAsync();
        Task<int> CheckPromotionLevelDuplication(PromotionLevel promotionLevel);
    }
}
