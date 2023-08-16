using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities.Account
{
    public class UserLocation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int UserLocationId { get; set; }
        public int LocationCode { get; set; }

        [ForeignKey("EnterUserLocationId")] 
        public ICollection<Enterprise> Enterprises { get; set; }
    }
}
