using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using DIMS.Entities.Account;

namespace DIMS.Helpers
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUsers,IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUsers> userManager, 
            RoleManager<IdentityRole> roleManager,IOptions<IdentityOptions> options)
            :base(userManager,roleManager,options)
            {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUsers users)
        {
            var identity = await base.GenerateClaimsAsync(users);
            identity.AddClaim(new Claim("UserLocationId",  users.LocationId.ToString() ?? ""));
            identity.AddClaim(new Claim("UserLocationCode", users.LocationCode.ToString() ?? ""));
            identity.AddClaim(new Claim("UserLocation", users.LocationName ?? ""));
            identity.AddClaim(new Claim("UserFirstName", users.FirstName ?? ""));
            identity.AddClaim(new Claim("UserMiddleName", users.MiddleName ?? ""));          
            identity.AddClaim(new Claim("UserRole", users.RoleName ?? ""));
            identity.AddClaim(new Claim("AccountId", users.Id ?? ""));
            return identity;
        }
    }
}
