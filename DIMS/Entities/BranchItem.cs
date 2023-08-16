using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class BranchItem
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "Branch Name is Requird")]
        public string BranchItemName { get; set; }
        public int BranchId { get; set; }
        public string Description { get; set; }

        public virtual Branch Branch { get; set; }
        [ForeignKey("BranchItemId")]
        public virtual ICollection<Enterprise> Enterprises { get; set; }

    }
}
