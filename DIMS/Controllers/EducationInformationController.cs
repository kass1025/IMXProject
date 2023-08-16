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
    public class EducationInformationController : Controller
    {
        private readonly IEducationLevelRepository  _IeducationLevelRepository;
        private readonly IEducationTypeRepository  _IeducationTypeRepository;
        private readonly IMemberRepository _ImemberRepository;
        private readonly IEducationInformationRepository _IeducationInformationRepository;
        public EducationInformationController(IEducationLevelRepository IeducationLevelRepository, IEducationTypeRepository IeducationTypeRepository, IMemberRepository ImemberRepository, IEducationInformationRepository IeducationInformationRepository )
        {
            _IeducationLevelRepository = IeducationLevelRepository;
            _IeducationTypeRepository = IeducationTypeRepository;
            _ImemberRepository = ImemberRepository;
            _IeducationInformationRepository = IeducationInformationRepository;
        }
        [Route("EduInfo/{id}")]
        public async Task<IActionResult> Index(bool isSuccess = false, string DuplicateError = "", int id=0)
        {
            int InterPriseLocation = int.Parse(User.FindFirst("UserLocationId").Value);
            //int LocationId = await _IenterpriseRepository.GetUserLocationIdAsync(InterPriseLocation);
            int LocationCode = int.Parse(User.FindFirst("UserLocationCode").Value);
            int enterpriseId = (await _ImemberRepository.GetAllMemberAsync()).Where(x => x.Id == id).FirstOrDefault().EnterpriseId;
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
            ViewBag.EducationLevel = new SelectList(await _IeducationLevelRepository.GetAllEducationLevelAsync(), "Id", "LevelName");
            ViewBag.EducationType = new SelectList(await _IeducationTypeRepository.GetAllEducationTypeAsync(), "Id", "TypeName");
            ViewBag.Member = new SelectList((await _ImemberRepository.GetAllMemberAsync()).Where(x=>x.EnterpriseId== enterpriseId), "Id", "FirstName");
            ViewBag.GetAlleducationInformation = (await _IeducationInformationRepository.GetAllEducationInformationAsync()).Where(x => x.Member.Enterprise.Id == enterpriseId);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEducationInformation(EducationInformation educationInformation)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = 0;// await _IeducationInformationRepository.CheckEducationInformationDuplication(city);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "City name or code Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var Id = await _IeducationInformationRepository.AddNewEducationInformationAsync(educationInformation);
                    if (Id > 0)
                    {

                        return RedirectToAction(nameof(Index), new { isSuccess = true, Id =educationInformation.MemberId });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(educationInformation);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
