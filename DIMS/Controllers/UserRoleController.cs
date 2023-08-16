using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIMS.Entities.Account;
using DIMS.IRepositories;

namespace DIMS.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRoleRepository _userRoleRepository;
      

        public UserRoleController(RoleManager<IdentityRole> roleManager, IUserRoleRepository IuserRoleRepository)
        {
            _userRoleRepository = IuserRoleRepository;
            _roleManager = roleManager;
          

        }

        public async Task<ActionResult> CreateRole(bool isSuccess = false)
        {
            //ViewBag.isSuccess = isSuccess;
            ViewBag.userRoles = await _userRoleRepository.GetAllUsersRoleAsync();
            return View();
        }
  
        [HttpPost]
        public async Task<ActionResult> CreateRole(UserRoles userRoles )
        {
            if (ModelState.IsValid)
            {
                var result = await _userRoleRepository.CreateUserRoleAsync(userRoles);
                if (result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    ViewBag.userRoles = await _userRoleRepository.GetAllUsersRoleAsync();
                    return View(userRoles);
                }
                ModelState.Clear();
                
            }
            return RedirectToAction(nameof(CreateRole), new { isSuccess = true });

        }      
        
    }
}
