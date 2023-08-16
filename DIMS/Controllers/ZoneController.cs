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
    public class ZoneController : Controller
    {
        private readonly IZoneRepository _IzoneRepository;
        private readonly IRegionRepository _IregionRepository;
        public ZoneController(IZoneRepository IzoneRepository, IRegionRepository IregionRepository)
        {
            _IzoneRepository = IzoneRepository;
            _IregionRepository = IregionRepository;
        }
        public async Task<IActionResult> Index(bool isSuccess = false, string DuplicateError = "")
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
            ViewBag.Regions = new SelectList(await _IregionRepository.GetAllRegionAsync(), "Id", "RegionName");
            ViewBag.GetAllZones = await _IzoneRepository.GetZonesAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewZone(Zone zone)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IzoneRepository.CheckZoneDuplication(zone);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Zone name or code Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IzoneRepository.AddNewZoneAsync(zone);
                    if (id > 0)
                    {

                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(zone);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
