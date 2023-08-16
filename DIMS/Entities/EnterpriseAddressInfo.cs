using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class EnterpriseAddressInfo
    {
        public int Id { get; set; }
        [StringLength(200, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 200")]
        [Required(ErrorMessage = "Member Addess is Requird")]
        public string EnterpriseAddress { get; set; }
        public int RegionId { get; set; }
        public int ZoneId { get; set; }
        public int WoredaId { get; set; }
        public int CityId { get; set; }
        public int EnterpriseId { get; set; }
        public string PhoneNumber  { get; set; }
        public string HouseNumber { get; set; }
        public string KebeleName { get; set; }

        public virtual Region Region { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual Woreda Woreda { get; set; }
        public virtual City City { get; set; }
        public virtual Enterprise Enterprise { get; set; }       
    }
}
