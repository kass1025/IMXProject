using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class Gender
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "Member Gender Name Requird")]
        public string GenderName { get; set; }
        public string Description { get; set; }
        [ForeignKey("GenderId")]
        public virtual ICollection<Member> Members { get; set; }
    }
}
