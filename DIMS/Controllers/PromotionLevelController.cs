using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class PromotionLevelController : Controller
    {
        private readonly IPromotionLevelRepository _IpromotionLevelRepository;
        public PromotionLevelController(IPromotionLevelRepository IpromotionLevelRepository)
        {
            _IpromotionLevelRepository = IpromotionLevelRepository;
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
            ViewBag.GetAllPromotionLevel = await _IpromotionLevelRepository.GetAllPromotionLevelAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPromotionLevel(PromotionLevel promotionLevel )
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _IpromotionLevelRepository.CheckPromotionLevelDuplication(promotionLevel);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Promotion Level name Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _IpromotionLevelRepository.AddNewPromotionLevelAsync(promotionLevel);
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(promotionLevel);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
