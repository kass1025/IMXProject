using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class Title
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "Member Title Name Requird")]
        public string TitleName { get; set; }
        public string Description { get; set; }

        [ForeignKey("TitleId")]
        public virtual ICollection<Member> Members  { get; set; }
    }
}
