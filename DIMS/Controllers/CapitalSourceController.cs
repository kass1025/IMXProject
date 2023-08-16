using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class CapitalSourceController : Controller
    {
        private readonly ICapitalSourceRepository _IcapitalSourceRepository;
        public CapitalSourceController(ICapitalSourceRepository IcapitalSourceRepository)
        {
            _IcapitalSourceRepository = IcapitalSourceRepository;
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
            ViewBag.GetAllCapitalSource = await _IcapitalSourceRepository.GetAllCapitalSourceAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCapitalSource(CapitalSource capitalSource)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IcapitalSourceRepository.CheckCapitalSourceDuplication(capitalSource);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "CapitalSource name Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IcapitalSourceRepository.AddNewCapitalSourceAsync(capitalSource);
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(capitalSource);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
