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
    public class MemberController : Controller
    {
        private readonly ITitleRepository _ItitleRepository;
        private readonly IGenderRepository _IgenderRepository;
        private readonly IDisabilityRepository _IdisabilityRepository;
        private readonly IEnterpriseRepository _IenterpriseRepository;
        private readonly IMemberRepository _ImemberRepository;
        private readonly IMemberTypeRepository _ImemberTypeRepository;        
        public MemberController(ITitleRepository IittleRepository, IGenderRepository IgenderRepository, IDisabilityRepository IdisabilityRepository, IMemberRepository ImemberRepository, IMemberTypeRepository ImemberTypeRepository, IEnterpriseRepository  IenterpriseRepository)
        {
            _ItitleRepository = IittleRepository;
            _IgenderRepository = IgenderRepository;
            _IdisabilityRepository = IdisabilityRepository;
            _IenterpriseRepository = IenterpriseRepository;
            _ImemberRepository = ImemberRepository;
            _ImemberTypeRepository = ImemberTypeRepository;
        }
        public async Task<IActionResult> Index(bool isSuccess = false, string DuplicateError = "")
        {
            int InterPriseLocation = int.Parse(User.FindFirst("UserLocationId").Value);
            int LocationId = await _IenterpriseRepository.GetUserLocationIdAsync(InterPriseLocation);
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
            ViewBag.Title = new SelectList(await _ItitleRepository.GetAllTitleAsync(), "Id", "TitleName");
            ViewBag.Gender = new SelectList(await _IgenderRepository.GetAllGenderAsync(), "Id", "GenderName");
            ViewBag.Disability = new SelectList(await _IdisabilityRepository.GetAllDisabilityAsync(), "Id", "DisabilityName");
            ViewBag.MemberType = new SelectList(await _ImemberTypeRepository.GetAllMemberTypeAsync(), "Id", "TypeName");
            ViewBag.Enterprise = new SelectList((await _IenterpriseRepository.GetAllEnterpriseAsync()).Where(x=>x.EnterUserLocationId== LocationId), "Id", "EnterpriseName");
            ViewBag.GetAllMember = (await _ImemberRepository.GetAllMemberAsync()).Where(x=>x.Enterprise.EnterUserLocationId== LocationId);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMember(Member member)
        {
            if (ModelState.IsValid)
            {
                //Check uplication
                int count = 0;// await _ImemberRepository.CheckMemberDuplication(member);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "House No. name or Phone No. Already  Exists!!";
                    return RedirectToAction(nameof(Index), new { isSuccess = true, DuplicateError = ViewBag.DuplicateError });
                }
                else
                {
                    var id = await _ImemberRepository.AddNewMemberAsync(member);
                    if (id > 0)
                    {

                        return RedirectToAction(nameof(Index), new { isSuccess = true , DuplicateError =""});
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Data");
                        ModelState.Clear();
                        return View(member);
                    }
                }
            }
            ModelState.Clear();
            return View();
        }
    }
}
