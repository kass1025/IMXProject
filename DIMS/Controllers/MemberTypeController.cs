using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class MemberTypeController : Controller
    {
        private readonly IMemberTypeRepository _ImemberTypeRepository;
        public MemberTypeController(IMemberTypeRepository ImemberTypeRepository)
        {
            _ImemberTypeRepository = ImemberTypeRepository;
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
            ViewBag.GetAllMemberType = await _ImemberTypeRepository.GetAllMemberTypeAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMemberType(MemberType memberType )
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = await _ImemberTypeRepository.CheckMemberTypeDuplication(memberType);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Member Type name Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _ImemberTypeRepository.AddNewMemberTypeAsync(memberType);
                    if (id > 0)
                    {
                        return RedirectToAction(nameof(Index), new { isSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(memberType);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
