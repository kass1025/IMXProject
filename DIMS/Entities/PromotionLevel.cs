using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Entities
{
    public class PromotionLevel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "String Length Between must be 50 and 100")]
        [Required(ErrorMessage = "Promotion Leve Name is Requird")]
        public string PromotionLeveName { get; set; }
        public string Description { get; set; }
        [ForeignKey("PromotionLevelId")]
        public virtual ICollection<Enterprise> Enterprises { get; set; }
    }
}
