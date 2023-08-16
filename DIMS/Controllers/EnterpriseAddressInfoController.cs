using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class EnterpriseAddressInfoController : Controller
    {
        private readonly IRegionRepository _IregionRepository;
        private readonly IZoneRepository  _IzoneRepository;
        private readonly IWoredaRepository  _IworedaRepository;
        private readonly ICityRepository  _IcityRepository;
        private readonly IEnterpriseRepository _IenterpriseRepository;
        private readonly IEnterpriseAddressInfoRepository  _IenterpriseAddressInfoRepository;        
        public EnterpriseAddressInfoController(IRegionRepository IregionRepository, IZoneRepository IzoneRepository, IWoredaRepository  IworedaRepository, ICityRepository  IcityRepository, IEnterpriseRepository  IenterpriseRepository, IEnterpriseAddressInfoRepository  IenterpriseAddressInfoRepository)
        {
            _IregionRepository = IregionRepository;
            _IzoneRepository = IzoneRepository;
            _IworedaRepository = IworedaRepository;
            _IcityRepository = IcityRepository;
            _IenterpriseRepository = IenterpriseRepository;
            _IenterpriseAddressInfoRepository = IenterpriseAddressInfoRepository;
            _IenterpriseRepository = IenterpriseRepository;
        }

        [Route("Index/{id}")]
        public async Task<IActionResult> Index(bool isSuccess = false, string DuplicateError = "", int id=0)
        {
            int InterPriseLocation = int.Parse(User.FindFirst("UserLocationId").Value);
            int LocationCode = int.Parse(User.FindFirst("UserLocationCode").Value);
            int LocationId = await _IenterpriseRepository.GetUserLocationIdAsync(InterPriseLocation);
            int woredaId = (await _IworedaRepository.GetWoredasAsync()).Where(x => x.WoredaCode == LocationCode).FirstOrDefault().Id;
            if (DuplicateError != "")
            {
                ViewBag.DuplicateErrormsg = DuplicateError;
                ViewBag.DuplicateError = true;
            }
            else
            {
                ViewBag.DuplicateError = false;
            }
            ViewBag.isSuccess = isSuccess;
            ViewBag.Region = new SelectList(await _IregionRepository.GetAllRegionAsync(), "Id", "RegionName");
            ViewBag.Zone = new SelectList((await _IzoneRepository.GetZonesAsync()).Where(x=>x.Id== InterPriseLocation), "Id", "ZoneName");
            ViewBag.Woreda = new SelectList((await _IworedaRepository.GetWoredasAsync()).Where(x=>x.WoredaCode== LocationCode), "Id", "WoredaName");
            ViewBag.City = new SelectList((await _IcityRepository.GetCitiesAsync()).Where(x => x.WoredaId == woredaId), "Id", "CityName");
            ViewBag.Enterprise = new SelectList((await _IenterpriseRepository.GetAllEnterpriseAsync()).Where(x=>x.EnterUserLocationId== LocationId && x.Id==id), "Id", "EnterpriseName");
            ViewBag.GetAllEnterpriseAddressInfo =( await _IenterpriseAddressInfoRepository.GetAllEnterpriseAddressInfoAsync()).Where(x => x.Enterprise.EnterUserLocationId == LocationId && x.EnterpriseId == id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEnterpriseAddressInfo(EnterpriseAddressInfo enterpriseAddressInfo)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IenterpriseAddressInfoRepository.CheckEnterpriseAddressInfoDuplication(enterpriseAddressInfo);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "House No. name or Phone No. Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IenterpriseAddressInfoRepository.AddNewEnterpriseAddressInfoAsync(enterpriseAddressInfo);
                    if (id > 0)
                    {

                        return RedirectToAction(nameof(Index), new { isSuccess = true, id= enterpriseAddressInfo.EnterpriseId });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(enterpriseAddressInfo);
                    }
                }
            }
            ModelState.Clear();
            return RedirectToAction(nameof(Index), new { isSuccess = false, id = enterpriseAddressInfo.EnterpriseId });
        }
    }
}
