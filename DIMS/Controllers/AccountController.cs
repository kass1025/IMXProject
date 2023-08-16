using DIMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Identity;
using DIMS.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using DIMS.Entities.Account;
using DIMS.ViewModel;

namespace DIMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _IaccountRepository;
        private readonly IUserRoleRepository _IuserRoleRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRegionRepository _IregionRepository;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _IsignInManager;
        private readonly IZoneRepository _IzoneRepository;
        private readonly ICityRepository _IcityRepository;
        private readonly IWoredaRepository _IworedaRepository;
        public AccountController(IWoredaRepository IworedaRepository, ICityRepository IcityRepository, IZoneRepository IzoneRepository, SignInManager<ApplicationUsers> IsignInManager, IUserRoleRepository IuserRoleRepository, IAccountRepository IaccountRepository, ITitleRepository ItitleRepository, IRegionRepository IregionRepository, RoleManager<IdentityRole> roleManager)
        {
            _IworedaRepository = IworedaRepository;
            _IcityRepository = IcityRepository;
            _IaccountRepository = IaccountRepository;
            _IuserRoleRepository = IuserRoleRepository;
            _roleManager = roleManager;
            _IregionRepository = IregionRepository;
            _IsignInManager = IsignInManager;
            _IzoneRepository = IzoneRepository;
        }

        //public async Task<IActionResult> UserProfile()
        //{
        //    //ViewBag.isSuccess = isSuccess;
        //    string accId = User.FindFirst("AccountId").Value;
        //    //ViewBag.UserProfile = await _IaccountRepository.GetAllUsersByIdAsync(accId);
        //    return View();
        //}

        public async Task<ActionResult> Signup(bool isSuccess = false)
        {
            string userRole = User.FindFirst("UserRole").Value;
            string accId = User.FindFirst("AccountId").Value;
            var LocationCode = (await _IaccountRepository.GetAllUsersByIdAsync(accId));


            if (userRole == "SuperAdmin")
            {
                ViewBag.users = (await _IaccountRepository.GetAllUsersAsync()).Where(x => x.RoleName == "Admin");
                ViewBag.userLocation = new SelectList((await _IregionRepository.GetAllRegionAsync()), "Id", "RegionName");
                ViewBag.userRoles = new SelectList((await _IuserRoleRepository.GetAllUsersRoleAsync()).Where(x => x.Name == "Admin"), "Name", "Name");
            }
            else if (userRole == "Admin")
            {
                int RegionCode = (await _IregionRepository.GetAllRegionAsync()).Where(x => x.RegionCode == LocationCode.FirstOrDefault().LocationCode).FirstOrDefault().RegionCode;
                ViewBag.users = (await _IaccountRepository.GetAllUsersAsync()).Where(x =>x.LocationCode==RegionCode && x.RoleName != "SuperAdmin");
                ViewBag.userLocation = new SelectList((await _IregionRepository.GetAllRegionAsync()).Where(x => x.RegionCode == LocationCode.FirstOrDefault().LocationCode), "Id", "RegionName");
                ViewBag.Zone = new SelectList((await _IzoneRepository.GetZonesAsync()).Where(x => x.Region.RegionCode == LocationCode.FirstOrDefault().LocationCode), "Id", "ZoneName");
                ViewBag.City = new SelectList((await _IcityRepository.GetCitiesAsync()).Where(x => x.Zone.Region.RegionCode == LocationCode.FirstOrDefault().LocationCode), "Id", "CityName");
                ViewBag.userRoles = new SelectList((await _IuserRoleRepository.GetAllUsersRoleAsync()).Where(x => x.Name != "Admin" && x.Name != "WAdmin" && x.Name != "SuperAdmin"), "Name", "Name");
            }
            else if (userRole == "ZAdmin")
            {

                ViewBag.users = (await _IaccountRepository.GetAllUsersAsync()).Where(x =>x.ParentId==LocationCode.FirstOrDefault().LocationId);
                ViewBag.userLocation = new SelectList((await _IregionRepository.GetAllRegionAsync()).Where(x => x.Zones.FirstOrDefault().Region.RegionCode == LocationCode.FirstOrDefault().LocationCode), "Id", "RegionName");
                ViewBag.Woreda = new SelectList((await _IworedaRepository.GetWoredasAsync()).Where(x => x.Zone.ZoneCode == LocationCode.FirstOrDefault().LocationCode), "Id", "WoredaName");
                ViewBag.Zone = new SelectList((await _IzoneRepository.GetZonesAsync()).Where(x => x.ZoneCode == LocationCode.FirstOrDefault().LocationCode), "Id", "ZoneName");
                ViewBag.City = new SelectList((await _IcityRepository.GetCitiesAsync()).Where(x => x.Zone.ZoneCode == LocationCode.FirstOrDefault().LocationCode), "Id", "CityName");
                ViewBag.userRoles = new SelectList((await _IuserRoleRepository.GetAllUsersRoleAsync()).Where(x => x.Name != "Admin" && x.Name != "ZAdmin" && x.Name != "SuperAdmin"), "Name", "Name");
            }
            else if (userRole == "WAdmin")
            {
                ViewBag.users = (await _IaccountRepository.GetAllUsersAsync()).Where(x => x.LocationCode == LocationCode.FirstOrDefault().LocationCode);
                ViewBag.userLocation = new SelectList((await _IregionRepository.GetAllRegionAsync()).Where(x => x.Id == LocationCode.FirstOrDefault().LocationCode), "Id", "RegionName");
                ViewBag.Woreda = new SelectList((await _IworedaRepository.GetWoredasAsync()).Where(x => x.WoredaCode == LocationCode.FirstOrDefault().LocationCode), "Id", "WoredaName");
                ViewBag.Zone = new SelectList((await _IzoneRepository.GetZonesAsync()).Where(x => x.Id == LocationCode.FirstOrDefault().LocationCode), "Id", "ZoneName");
                ViewBag.City = new SelectList((await _IcityRepository.GetCitiesAsync()).Where(x => x.Zone.Id == LocationCode.FirstOrDefault().LocationCode), "Id", "CityName");
                ViewBag.userRoles = new SelectList((await _IuserRoleRepository.GetAllUsersRoleAsync()).Where(x => x.Name != "WAdmin" && x.Name != "CAdmin" && x.Name != "Admin" && x.Name != "ZAdmin" && x.Name != "SuperAdmin"), "Name", "Name");
            }
            else if (userRole == "CAdmin")
            {
                ViewBag.users = (await _IaccountRepository.GetAllUsersAsync()).Where(x => x.LocationCode == LocationCode.FirstOrDefault().LocationCode );
                ViewBag.userLocation = new SelectList((await _IregionRepository.GetAllRegionAsync()).Where(x => x.Id == LocationCode.FirstOrDefault().LocationCode), "Id", "RegionName");
                ViewBag.Woreda = new SelectList((await _IworedaRepository.GetWoredasAsync()).Where(x => x.Id == LocationCode.FirstOrDefault().LocationCode), "Id", "WoredaName");
                ViewBag.Zone = new SelectList((await _IzoneRepository.GetZonesAsync()).Where(x => x.Id == LocationCode.FirstOrDefault().LocationCode), "Id", "ZoneName");
                ViewBag.City = new SelectList((await _IcityRepository.GetCitiesAsync()).Where(x => x.CityCode == LocationCode.FirstOrDefault().LocationCode), "Id", "CityName");
                ViewBag.userRoles = new SelectList((await _IuserRoleRepository.GetAllUsersRoleAsync()).Where(x => x.Name != "WAdmin" && x.Name != "CAdmin" && x.Name != "Admin" && x.Name != "ZAdmin" && x.Name != "SuperAdmin"), "Name", "Name");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Signup(AccountRegistrationViewModel accountRegistrationView)
        {
            accountRegistrationView.RegistrationInValid = "true";
            //if (ModelState.IsValid)
            // {
            string accId = User.FindFirst("AccountId").Value;
            string userRole = User.FindFirst("UserRole").Value;
            int userLocationId = (await _IaccountRepository.GetAllUsersByIdAsync(accId)).Select(x => x.LocationId).FirstOrDefault();
            int count = await _IaccountRepository.CheckUserAccountItemDuplication(accountRegistrationView);
            //if yes throw an error message
            if (count > 0)
            {
                ViewBag.DuplicateError = "Already Exists!!";
                ModelState.AddModelError(string.Empty, "You can not register same email and phone number!");
                return RedirectToAction(nameof(Signup), new { isSuccess = false });
            }
            else
            {
                var result = await _IaccountRepository.CreateUserAsync(accountRegistrationView);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    ViewBag.users = await _IaccountRepository.GetAllUsersAsync();
                    return View(accountRegistrationView);
                }
            }
            ModelState.Clear();
            // }
            return RedirectToAction(nameof(Signup), new { isSuccess = true });

        }

        public IActionResult Login(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel loginViewModel)
        {
            loginViewModel.LoginInValid = "true";
            if (ModelState.IsValid)
            {
                var rolename = (await _IaccountRepository.GetAllUsersAsync()).Where(x => x.Email == loginViewModel.Email).Select(x => x.RoleName).FirstOrDefault();
                var result = await _IaccountRepository.SignInAsync(loginViewModel);
                if (result.Succeeded)
                {
                    if (rolename == "Tv")
                    {
                        return RedirectToAction("Index", "TvDisplay", new { isSuccess = true });
                    }
                    else if (rolename == "Public")
                    {
                        return RedirectToAction("ShowPublicPatientHistory", "Patient", new { isSuccess = false });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { isSuccess = true });
                    }
                }
                ModelState.AddModelError("", "Invalid Credential");
            }
            return View(loginViewModel);
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _IaccountRepository.SignOutAsync();
            return View("login");
        }

    }
}
