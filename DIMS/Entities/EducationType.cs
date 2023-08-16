using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class EducationType
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "Education Type Name Requird")]
        public string TypeName { get; set; }
        public string Description { get; set; }

        [ForeignKey("EducationTypeId")]
        public virtual ICollection<EducationInformation> EducationInformation { get; set; }

    }
}
