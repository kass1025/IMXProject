using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class EducationLevelController : Controller
    {
        private readonly IEducationLevelRepository _IeducationLevelRepository;
        public EducationLevelController(IEducationLevelRepository IeducationLevelRepository)
        {
            _IeducationLevelRepository = IeducationLevelRepository;
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
            ViewBag.GetAllEducationLevel = await _IeducationLevelRepository.GetAllEducationLevelAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEducationLevel(EducationLevel educationLevel)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IeducationLevelRepository.CheckEducationLevelDuplication(educationLevel);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Education Level name Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IeducationLevelRepository.AddNewEducationLevelAsync(educationLevel);
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(educationLevel);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
