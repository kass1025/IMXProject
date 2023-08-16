using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIMS.Entities.LanguagesEntities;

namespace DIMS.IRepositories.ILanguageRepository
{
    public interface ILocalizationService
    {
        StringResource GetStringResource(string resourceKey, int languageId);
    }
}
