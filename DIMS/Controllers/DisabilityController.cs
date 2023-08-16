using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class DisabilityController : Controller
    {
        private readonly IDisabilityRepository _IdisabilityRepository;
        public DisabilityController(IDisabilityRepository IdisabilityRepository)
        {
            _IdisabilityRepository = IdisabilityRepository;
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
            ViewBag.GetAllDisability = await _IdisabilityRepository.GetAllDisabilityAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTitle(Disability disability)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IdisabilityRepository.CheckDisabilityDuplication(disability);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Disability name Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IdisabilityRepository.AddNewDisabilityAsync(disability);
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(disability);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
