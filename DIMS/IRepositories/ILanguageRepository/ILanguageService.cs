using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIMS.Entities.LanguagesEntities;

namespace DIMS.IRepositories.ILanguageRepository
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguageByCulture(string culture);
    }
}
