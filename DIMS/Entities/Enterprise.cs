using DIMS.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class Enterprise
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "Enterprise Name is Requird")]
        public string EnterpriseName { get; set; }
        public string TINNumber  { get; set; }
        [Range(0.00, 99999999.99)]
        public decimal InitialCapital { get; set; }
        [Range(0.00, 99999999.99)]
        public decimal? CurrentCapital { get; set; }
        public int FoundedYear { get; set; }
        public int CapitalSourceId { get; set; }
        public int GroupTypeId  { get; set; }
        public int BranchItemId { get; set; }
        public int PromotionLevelId { get; set; }
        public int EnterpriseLevelId { get; set; }
        public int EnterpriseStatusId { get; set; }
        public int EnterUserLocationId { get; set; }
        public int MaleFouder { get; set; }
        public int FemaleFounder { get; set; }
        public int MaleFouderYear { get; set; }
        public int FemaleFounderYear { get; set; }
        public int MaleCollege { get; set; }
        public int FemaleCollege { get; set; }
        public int MaleUniversity { get; set; }
        public int FemaleUniversity { get; set; } 
        public virtual UserLocation UserLocation  { get; set; }
        public virtual CapitalSource CapitalSource { get; set; }
        public virtual GroupType GroupType { get; set; }
        public virtual BranchItem BranchItem { get; set; }
        public virtual PromotionLevel PromotionLevel { get; set; }
        public virtual EnterpriseLevel EnterpriseLevel { get; set; }
        public virtual EnterpriseStatus EnterpriseStatus { get; set; }

        [ForeignKey("EnterpriseId")]
        public virtual ICollection<EnterpriseAddressInfo> EnterpriseAddressInfos { get; set; }
        [ForeignKey("EnterpriseId")]
        public virtual ICollection<Member> Members { get; set; }
       
    }
}
