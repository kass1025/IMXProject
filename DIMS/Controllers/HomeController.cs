using DIMS.Entities.LanguagesEntities;
using DIMS.IRepositories;
using DIMS.IRepositories.ILanguageRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class HomeController :  BaseController
    {
        private readonly IAccountRepository _IaccountRepository;
        private readonly IRegionRepository _IregionRepository ;
       
        public HomeController(ILanguageService languageService, ILocalizationService localizationService, IAccountRepository IaccountRepository, IRegionRepository IregionRepository)
           : base(languageService, localizationService)
        {
            _IaccountRepository = IaccountRepository;
            _IregionRepository = IregionRepository;

        }
      
        public async Task<ViewResult> Index()
        {
            try
            {
                if (User.FindFirst("AccountId").Value != null)
                {
                    string accId = User.FindFirst("AccountId").Value;
                    int locationId = (await _IaccountRepository.GetAllUsersByIdAsync(accId)).Select(x => x.LocationId).FirstOrDefault();
                    ViewBag.UserLocation = (await _IregionRepository.GetAllRegionAsync()).Where(x => x.Id == locationId).Select(x => x.RegionName).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            // ViewBag.Services = (await _IpatientServiceRepository.GetDailyServices()).Where(x => x.ServiceDate >= Convert.ToDateTime("10/10/2021") && x.UserName== User.FindFirst("FullName").Value);
            return View();

        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                }
            );

            return LocalRedirect(returnUrl);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
