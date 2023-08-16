using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class Member
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "First Name Requird")]
        public string FirstName { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "Middle Name Requird")]
        public string MiddleName { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "Last Name Requird")]
        public string LastName { get; set; }
        public bool IsDisable { get; set; }
        public int TitleId { get; set; }
        public int GenderId { get; set; }
        public int MemberTypeId { get; set; }
        public int? DisabilityId { get; set; }
        public string Role { get; set; }
        public DateTime DateOfJoing { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public int EnterpriseId  { get; set; }
        public bool IsFounder { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public virtual MemberType MemberType { get; set; }
        public virtual Gender Gender  { get; set; }
        public virtual Title Title  { get; set; }
        public virtual Disability Disability  { get; set; }

        [ForeignKey("MemberId")]
        public virtual ICollection<EducationInformation> EducationInformation   { get; set; }

        [ForeignKey("MemberId")]
        public virtual ICollection<MemberAddressInfo> MemberAddressInfos { get; set; }
    }
}
