using DIMS.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class Zone
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "Zone Name Requird"),Display(Name ="Zone Name")]
        public string ZoneName { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Zone Code is Requird")]
        public int ZoneCode { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region  { get; set; }

        [ForeignKey("ZoneId")]
        public virtual ICollection<Woreda> Woredas { get; set; }
        [ForeignKey("ZoneId")]
        public virtual ICollection<City> Cities { get; set; }

        [ForeignKey("ZoneId")]
        public virtual ICollection<MemberAddressInfo> MemberAddressInfos { get; set; }
        [ForeignKey("ZoneId")]
        public virtual ICollection<EnterpriseAddressInfo> EnterpriseAddressInfos { get; set; }
      

    }
}
