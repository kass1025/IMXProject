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
    public class LanguageService : ILanguageService
    {
        private readonly DIMSDbContext _dbContext = null;

        public LanguageService(DIMSDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _dbContext.Languages.ToList();
        }

        public Language GetLanguageByCulture(string culture)
        {
            return _dbContext.Languages.FirstOrDefault(x => 
                x.Culture.Trim().ToLower() == culture.Trim().ToLower());
        } 
    }
}
