using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchRepository _IbranchRepository;
        public BranchController(IBranchRepository IbranchRepository)
        {
            _IbranchRepository = IbranchRepository;
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
            ViewBag.GetAllBranch = await _IbranchRepository.GetAllBranchAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBranch(Branch branch)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IbranchRepository.CheckBranchDuplication(branch);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Branch name Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IbranchRepository.AddNewBranchAsync(branch);
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(branch);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
