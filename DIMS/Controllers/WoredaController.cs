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
    public class WoredaController : Controller
    {
        private readonly IZoneRepository _IzoneRepository;
        private readonly IWoredaRepository _IworedaRepository;
        public WoredaController(IZoneRepository IzoneRepository, IWoredaRepository IworedaRepository )
        {
            _IzoneRepository = IzoneRepository;
            _IworedaRepository = IworedaRepository;
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
            ViewBag.Zones = new SelectList((await _IzoneRepository.GetZonesAsync()).Where(x=>x.ZoneName== ZoneName), "Id", "ZoneName");
            ViewBag.GetAllWoredas = (await _IworedaRepository.GetWoredasAsync()).Where(x=>x.Zone.ZoneName== ZoneName);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewWoreda(Woreda woreda)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IworedaRepository.CheckWoredaDuplication(woreda);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Zone name or code Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IworedaRepository.AddNewWoredaAsync(woreda);
                    if (id > 0)
                    {

                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(woreda);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
