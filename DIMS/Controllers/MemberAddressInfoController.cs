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
    public class MemberAddressInfoController : Controller
    {
        private readonly IRegionRepository _IregionRepository;
        private readonly IZoneRepository  _IzoneRepository;
        private readonly IWoredaRepository  _IworedaRepository;
        private readonly ICityRepository  _IcityRepository;
        private readonly IMemberRepository _ImemberRepository;
        private readonly IMemberAddressInfoRepository _ImemberAddressInfoRepository;
        private readonly IEnterpriseRepository _IenterpriseRepository;
        public MemberAddressInfoController(IEnterpriseRepository IenterpriseRepository,IRegionRepository IregionRepository, IZoneRepository IzoneRepository, IWoredaRepository IworedaRepository, ICityRepository IcityRepository, IMemberRepository ImemberRepository, IMemberAddressInfoRepository ImemberAddressInfoRepository)
        {
            _IregionRepository = IregionRepository;
            _IzoneRepository = IzoneRepository;
            _IworedaRepository = IworedaRepository;
            _IcityRepository = IcityRepository;
            _ImemberRepository = ImemberRepository;
            _ImemberAddressInfoRepository = ImemberAddressInfoRepository;
            _IenterpriseRepository = IenterpriseRepository;
        }
        [Route("MemberAddress/{id}")]
        public async Task<IActionResult> Index(bool isSuccess = false, string DuplicateError = "", int id=0)
        {
            int InterPriseLocation = int.Parse(User.FindFirst("UserLocationId").Value);
            int LocationId = await _IenterpriseRepository.GetUserLocationIdAsync(InterPriseLocation);      
            int LocationCode = int.Parse(User.FindFirst("UserLocationCode").Value);
            int woredaId = (await _IworedaRepository.GetWoredasAsync()).Where(x => x.WoredaCode == LocationCode).FirstOrDefault().Id;
            int enterpriseId = (await _ImemberRepository.GetAllMemberAsync()).Where(x => x.Id == id).FirstOrDefault().EnterpriseId;
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
            ViewBag.Zone = new SelectList((await _IzoneRepository.GetZonesAsync()).Where(x => x.Id == InterPriseLocation), "Id", "ZoneName");
            ViewBag.Woreda = new SelectList((await _IworedaRepository.GetWoredasAsync()).Where(x => x.WoredaCode == LocationCode), "Id", "WoredaName");
            ViewBag.City = new SelectList((await _IcityRepository.GetCitiesAsync()).Where(x => x.WoredaId == woredaId), "Id", "CityName");
            ViewBag.Member = new SelectList((await _ImemberRepository.GetAllMemberAsync()).Where(x=>x.EnterpriseId==enterpriseId), "Id", "FirstName");
            ViewBag.GetAllMemberAddressInfo  = (await _ImemberAddressInfoRepository.GetAllMemberAddressInfoAsync()).Where(x=> x.Member.Enterprise.Id == enterpriseId);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMemberAddressInfo(MemberAddressInfo memberAddressInfo)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = 0;// await _ImemberAddressInfoRepository.CheckMemberAddressInfoDuplication(memberAddress);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "House No. name or Phone No. Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var Id = await _ImemberAddressInfoRepository.AddNewMemberAddressInfoAsync(memberAddressInfo);
                    if (Id > 0)
                    {

                        return RedirectToAction(nameof(Index), new { isSuccess = true, Id =memberAddressInfo.MemberId });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(memberAddressInfo);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
