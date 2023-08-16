using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIMS.DIMSDataContext;
using DIMS.Entities.LanguagesEntities;
using DIMS.IRepositories.ILanguageRepository;
using Microsoft.EntityFrameworkCore;

namespace DIMS.Repositories.LanguageRepository
{
    public class LocalizationService : ILocalizationService
    {
        private readonly DIMSDbContext _dbContext = null;
        public LocalizationService(DIMSDbContext context)
        {
            _dbContext = context;
        }

        public StringResource GetStringResource(string resourceKey, int languageId)
        {
            return _dbContext.StringResources.FirstOrDefault(x => 
                    x.Name.Trim().ToLower() == resourceKey.Trim().ToLower() 
                    && x.LanguageId == languageId);
        }
    }
}
