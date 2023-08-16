using DIMS.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class City
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "City Name Requird")]
        public string CityName { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "City Code is Requird")]
        public int CityCode { get; set; }
        public int? ZoneId { get; set; }
        public int? WoredaId { get; set; }

        public virtual Zone Zone  { get; set; }
        public virtual Woreda Woreda { get; set; }

        [ForeignKey("CityId")]
        public virtual ICollection<MemberAddressInfo> MemberAddressInfos { get; set; }
        [ForeignKey("CityId")]
        public virtual ICollection<EnterpriseAddressInfo> EnterpriseAddressInfos { get; set; }        
    }
}
