using DIMS.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class Region
    {
        public int Id { get; set; }
        [StringLength(100,MinimumLength =2, ErrorMessage ="String Length Between must be 50 and 100")]
        [Required(ErrorMessage ="Region Name Requird")]
        public string RegionName { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Region Code is Requird")]
        public int RegionCode { get; set; }

        [ForeignKey("RegionId")]
        public virtual ICollection<Zone> Zones { get; set; }

        [ForeignKey("RegionId")]
        public virtual ICollection<MemberAddressInfo> MemberAddressInfos { get; set; }
        [ForeignKey("RegionId")]
        public virtual ICollection<EnterpriseAddressInfo> EnterpriseAddressInfos  { get; set; }       
    }
}
