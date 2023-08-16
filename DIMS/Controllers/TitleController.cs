using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class TitleController : Controller
    {
        private readonly ITitleRepository _ItitleRepository;
        public TitleController(ITitleRepository ItitleRepository)
        {
            _ItitleRepository = ItitleRepository;
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
            ViewBag.GetAllTitles = await _ItitleRepository.GetAllTitleAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTitle(Title title)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _ItitleRepository.CheckTitleDuplication(title);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Region name or code Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _ItitleRepository.AddNewTitleAsync(title);
                    if (id > 0)
                    {

                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(title);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
