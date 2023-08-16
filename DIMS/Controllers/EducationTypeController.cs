using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class EducationTypeController : Controller
    {
        private readonly IEducationTypeRepository _IeducationTypeRepository;
        public EducationTypeController(IEducationTypeRepository IeducationTypeRepository)
        {
            _IeducationTypeRepository = IeducationTypeRepository;
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
            ViewBag.GetAllEducationType = await _IeducationTypeRepository.GetAllEducationTypeAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEducationType(EducationType educationType)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IeducationTypeRepository.CheckEducationTypeDuplication(educationType);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Education Type name Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IeducationTypeRepository.AddNewEducationTypeAsync(educationType);
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(educationType);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
