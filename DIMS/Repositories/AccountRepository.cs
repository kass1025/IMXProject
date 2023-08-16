using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DIMS.DIMSDataContext;
using DIMS.Entities.Account;
using DIMS.ViewModel;

namespace DIMS.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DIMSDbContext _dbContext = null;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _signInManager;

        public AccountRepository(DIMSDbContext dataContext, UserManager<ApplicationUsers> userManager, SignInManager<ApplicationUsers> signInManager)
        {
            _dbContext = dataContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IEnumerable<ApplicationUsers>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
        public async Task<IEnumerable<ApplicationUsers>> GetAllUsersByIdAsync(string id)
        {
            return await _userManager.Users.Where(x => x.Id == id).ToListAsync();
        }
        public async Task<SignInResult> SignInAsync(UserLoginViewModel loginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<IdentityResult> CreateUserAsync(AccountRegistrationViewModel accountRegistrationView)
        {
            int LocationId;
            int UserLocationCode;
            string UserLocation;
            int ParentId=0;
            if (accountRegistrationView.CLocationId != 0)
            {
                LocationId = accountRegistrationView.CLocationId;
                ParentId = _dbContext.Cities.Find(LocationId).ZoneId.Value;
                UserLocation = Convert.ToString(await _dbContext.Cities.Where(x => x.Id == accountRegistrationView.CLocationId).Select(x => x.CityName).FirstOrDefaultAsync());
                UserLocationCode = await _dbContext.Cities.Where(x => x.Id == accountRegistrationView.CLocationId).Select(x => x.CityCode).FirstOrDefaultAsync();
            }
            else if (accountRegistrationView.ZLocationId != 0)
            {
                LocationId = accountRegistrationView.ZLocationId;
                ParentId = LocationId;
                UserLocation = Convert.ToString(await _dbContext.Zones.Where(x => x.Id == accountRegistrationView.ZLocationId).Select(x => x.ZoneName).FirstOrDefaultAsync());
                UserLocationCode = await _dbContext.Zones.Where(x => x.Id == accountRegistrationView.ZLocationId).Select(x => x.ZoneCode).FirstOrDefaultAsync();
            }
            else if (accountRegistrationView.WLocationId != 0)
            {
                LocationId = accountRegistrationView.WLocationId;
                ParentId = _dbContext.Woredas.Find(LocationId).ZoneId;
                UserLocation = Convert.ToString(await _dbContext.Woredas.Where(x => x.Id == accountRegistrationView.WLocationId).Select(x => x.WoredaName).FirstOrDefaultAsync());
                UserLocationCode = await _dbContext.Woredas.Where(x => x.Id == accountRegistrationView.WLocationId).Select(x => x.WoredaCode).FirstOrDefaultAsync();
            }
            else
            {
                LocationId = accountRegistrationView.LocationId;
                UserLocation = Convert.ToString(await _dbContext.Regions.Where(x => x.Id == accountRegistrationView.LocationId).Select(x => x.RegionName).FirstOrDefaultAsync());
                UserLocationCode = await _dbContext.Regions.Where(x => x.Id == accountRegistrationView.LocationId).Select(x => x.RegionCode).FirstOrDefaultAsync();
            }
            var user = new ApplicationUsers()
            {
                Email = accountRegistrationView.Email,
                UserName = accountRegistrationView.Email,
                FirstName = accountRegistrationView.FirstName,
                MiddleName = accountRegistrationView.MiddleName,
                RoleName = accountRegistrationView.RoleName,
                LocationId = LocationId,
                PhoneNumber = accountRegistrationView.PhoneNumber,
                LocationName = UserLocation,
                LocationCode = UserLocationCode,
                ParentId= ParentId,
            };
            var result = await _userManager.CreateAsync(user, accountRegistrationView.Password);
            result = await _userManager.AddToRoleAsync(user, accountRegistrationView.RoleName);
            await AddUserLocation(user.Id, user.LocationId,user.LocationCode);
            return result;
        }

        public async Task<int> AddUserLocation(string userId, int RegionId, int locationCode)
        {
            var userLocation = new UserLocation()
            {
                UserId = userId,
                UserLocationId = RegionId,
                LocationCode = locationCode,
            };
            await _dbContext.UserLocations.AddAsync(userLocation);
            await _dbContext.SaveChangesAsync();
            return userLocation.Id;
        }
        public async Task<int> CheckUserAccountItemDuplication(AccountRegistrationViewModel account)
        {
            var _userAccount = await (from m in _dbContext.Users
                                      where m.Email == account.Email && m.PhoneNumber==account.PhoneNumber
                                      select m
                                       ).ToListAsync();
            return _userAccount.Count();
        }

    }
}
