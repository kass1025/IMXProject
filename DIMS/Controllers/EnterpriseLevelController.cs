using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class EnterpriseLevelController : Controller
    {
        private readonly IEnterpriseLevelRepository _IenterpriseLevelRepository;
        public EnterpriseLevelController(IEnterpriseLevelRepository IenterpriseLevelRepository)
        {
            _IenterpriseLevelRepository = IenterpriseLevelRepository;
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
            ViewBag.GetAllEnterpriseLevel = await _IenterpriseLevelRepository.GetAllEnterpriseLevelAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEnterpriseLevel(EnterpriseLevel enterpriseLevel)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IenterpriseLevelRepository.CheckEnterpriseLevelDuplication(enterpriseLevel);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Enterprise Level name Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IenterpriseLevelRepository.AddNewEnterpriseLevelAsync(enterpriseLevel);
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(enterpriseLevel);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
