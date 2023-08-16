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
    public class CityController : Controller
    {
        private readonly IZoneRepository _IzoneRepository;
        private readonly IWoredaRepository _IworedaRepository;
        private readonly ICityRepository _IcityRepository;
        public CityController(ICityRepository IcityRepository,IZoneRepository IzoneRepository, IWoredaRepository IworedaRepository)
        {
            _IzoneRepository = IzoneRepository;
            _IworedaRepository = IworedaRepository;
            _IcityRepository = IcityRepository;
        }
        public async Task<IActionResult> Index(bool isSuccess = false, string DuplicateError = "")
        {
            string ZoneName = User.FindFirst("UserLocation").Value;
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
            ViewBag.Zones = new SelectList((await _IzoneRepository.GetZonesAsync()).Where(x => x.ZoneName == ZoneName), "Id", "ZoneName");
            ViewBag.Woredas = new SelectList((await _IworedaRepository.GetWoredasAsync()).Where(x=>x.Zone.ZoneName== ZoneName), "Id", "WoredaName");
            ViewBag.GetAllCities =( await _IcityRepository.GetCitiesAsync()).Where(x=>x.Zone.ZoneName== ZoneName);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCity(City city)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IcityRepository.CheckCityDuplication(city);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "City name or code Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IcityRepository.AddNewCityAsync(city);
                    if (id > 0)
                    {

                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(city);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
