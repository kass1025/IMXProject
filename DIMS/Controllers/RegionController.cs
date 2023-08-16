using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionRepository _IregionRepository;
        public RegionController(IRegionRepository IregionRepository)
        {
            _IregionRepository = IregionRepository;
        }
        public async Task<ViewResult> Index(bool isSuccess = false, string DuplicateError = "")
        {
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
            ViewBag.GetAllRegions = await _IregionRepository.GetAllRegionAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRegion(Region region)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IregionRepository.RegionNameDuplicationCheck(region);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Region name or code Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IregionRepository.AddNewRegionAsync(region);
                    if (id > 0)
                    {

                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(region);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
