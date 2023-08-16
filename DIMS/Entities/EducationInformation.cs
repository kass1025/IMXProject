using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class EducationInformation
    {
        public int Id { get; set; }
        [StringLength(200, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 200")]
        [Required(ErrorMessage = "Institution Name is Requird")]
        public string InstitutionName { get; set; }
        public int EducationTypeId { get; set; }
        public int EducationLevelId { get; set; }
        public int MemberId { get; set; }
        public string Certificate  { get; set; }

        public virtual EducationLevel EducationLevel { get; set; }
        public virtual EducationType EducationType { get; set; }
        public virtual Member Member  { get; set; }
    }
}
