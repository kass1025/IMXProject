using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGenderRepository _IgenderRepository;
        public GenderController(IGenderRepository IgenderRepository)
        {
            _IgenderRepository = IgenderRepository;
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
            ViewBag.GetAllGender = await _IgenderRepository.GetAllGenderAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewGender(Gender gender)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IgenderRepository.CheckGenderDuplication(gender);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Region name or code Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IgenderRepository.AddNewGenderAsync(gender);
                    if (id > 0)
                    {

                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(gender);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
