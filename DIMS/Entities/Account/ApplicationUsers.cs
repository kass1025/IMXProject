using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities.Account
{
    public class ApplicationUsers : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string  RoleName { get; set; }
        public int LocationId { get; set; }
        public int LocationCode { get; set; }
        public string  LocationName  { get; set; }
        public int ParentId { get; set; }
        public string FullName
        {
            get
            {
                var FullName = LocationName + " " + (FirstName + " " + MiddleName);
                return FullName;
            }

        }

        [ForeignKey("UserId")]
        public ICollection<UserLocation> UserLocations { get; set; }
    }
}
