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
    public class BranchItemController : Controller
    {
        private readonly IBranchItemRepository _IbranchItemRepository;
        private readonly IBranchRepository _IbranchRepository;
        public BranchItemController(IBranchItemRepository IbranchItemRepository, IBranchRepository IbranchRepository)
        {
            _IbranchItemRepository = IbranchItemRepository; 
            _IbranchRepository = IbranchRepository;
        }
        public async Task<IActionResult> Index(bool isSuccess = false, string DuplicateError = "")
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
            ViewBag.Branches = new SelectList(await _IbranchRepository.GetAllBranchAsync(), "Id", "BranchName");
            ViewBag.GetAllBrancheItems = await _IbranchItemRepository.GetBranchItemAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBranchItem(BranchItem branchItem)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IbranchItemRepository.CheckBranchItemDuplication(branchItem);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "BranchItem name Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IbranchItemRepository.AddNewBranchItemAsync(branchItem);
                    if (id > 0)
                    {

                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(branchItem);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
