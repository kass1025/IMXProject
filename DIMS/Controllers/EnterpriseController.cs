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
    public class EnterpriseController : Controller
    {
        private readonly ICapitalSourceRepository _IcapitalSourceRepository;
        private readonly IGroupTypeRepository _IgroupTypeRepository;
        private readonly IBranchItemRepository _IbranchItemRepository;
        private readonly IPromotionLevelRepository _IpromotionLevelRepository;
        private readonly IEnterpriseLevelRepository _IenterpriseLevelRepository;
        private readonly IEnterpriseStatusRepository _IenterpriseStatusRepository;
        private readonly IEnterpriseRepository _IenterpriseRepository;
       
        public EnterpriseController(IEnterpriseRepository IenterpriseRepository,IEnterpriseStatusRepository IenterpriseStatusRepository,IEnterpriseLevelRepository IenterpriseLevelRepository,IPromotionLevelRepository IpromotionLevelRepository,ICapitalSourceRepository IcapitalSourceRepository, IGroupTypeRepository IgroupTypeRepository, IBranchItemRepository IbranchItemRepository)
        {
            _IcapitalSourceRepository = IcapitalSourceRepository;
            _IgroupTypeRepository = IgroupTypeRepository;
            _IbranchItemRepository = IbranchItemRepository;
            _IpromotionLevelRepository = IpromotionLevelRepository;
            _IenterpriseLevelRepository = IenterpriseLevelRepository;
            _IenterpriseStatusRepository = IenterpriseStatusRepository;
            _IenterpriseRepository = IenterpriseRepository;
        }

        public async Task<IActionResult> Index(bool isSuccess = false, string DuplicateError = "", int id = 0)
        {
            int InterPriseLocation = int.Parse(User.FindFirst("UserLocationId").Value);
            int LocationCode = int.Parse(User.FindFirst("UserLocationCode").Value);
            int LocationId = await _IenterpriseRepository.GetUserLocationIdAsync(InterPriseLocation);
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
            ViewBag.CapitalSource = new SelectList(await _IcapitalSourceRepository.GetAllCapitalSourceAsync(), "Id", "CapitalSourceName");
            ViewBag.GroupType = new SelectList(await _IgroupTypeRepository.GetAllGroupTypeAsync(), "Id", "GroupTypeName");
            ViewBag.BranchItem = new SelectList(await _IbranchItemRepository.GetBranchItemAsync(), "Id", "BranchItemName");
            ViewBag.PromotionLevel = new SelectList(await _IpromotionLevelRepository.GetAllPromotionLevelAsync(), "Id", "PromotionLeveName");
            ViewBag.EnterpriseLevel = new SelectList(await _IenterpriseLevelRepository.GetAllEnterpriseLevelAsync(), "Id", "EnterpriseLevelName");
            ViewBag.EnterpriseStatus = new SelectList(await _IenterpriseStatusRepository.GetAllEnterpriseStatusAsync(), "Id", "EnterpriseStatusName");
            ViewBag.GetAllEnterprise = (await _IenterpriseRepository.GetAllEnterpriseAsync()).Where(x=>x.EnterUserLocationId== LocationId);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEnterprise(Enterprise enterprise)
        {
            int InterPriseLocation = int.Parse(User.FindFirst("UserLocationId").Value);

            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IenterpriseRepository.CheckEnterpriseDuplication(enterprise);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Enterprise name or TIN No. Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IenterpriseRepository.AddNewEnterpriseAsync(enterprise, InterPriseLocation);
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError="" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(enterprise);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
