using DIMS.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class Woreda
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "Woreda Name Requird")]
        public string WoredaName { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Woreda Code is Requird")]
        public int WoredaCode { get; set; }
        public int ZoneId { get; set; }
        public virtual Zone Zone  { get; set; }

        [ForeignKey("WoredaId")]
        public virtual ICollection<City> Cities { get; set; }

        [ForeignKey("WoredaId")]
        public virtual ICollection<MemberAddressInfo> MemberAddressInfos { get; set; }
        [ForeignKey("WoredaId")]
        public virtual ICollection<EnterpriseAddressInfo> EnterpriseAddressInfos { get; set; }
   
    }

}
