using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class EnterpriseStatusController : Controller
    {
        private readonly IEnterpriseStatusRepository _IenterpriseStatusRepository;
        public EnterpriseStatusController(IEnterpriseStatusRepository IenterpriseStatusRepository)
        {
            _IenterpriseStatusRepository = IenterpriseStatusRepository;
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
            ViewBag.GetAllEnterpriseStatus = await _IenterpriseStatusRepository.GetAllEnterpriseStatusAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEnterpriseStatus(EnterpriseStatus enterpriseStatus )
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IenterpriseStatusRepository.CheckEnterpriseStatusDuplication(enterpriseStatus);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Enterprise Level name Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IenterpriseStatusRepository.AddNewEnterpriseStatusAsync(enterpriseStatus);
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(enterpriseStatus);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
