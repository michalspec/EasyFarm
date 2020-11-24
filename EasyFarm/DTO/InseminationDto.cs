using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFarm.DTO
{
    public class InseminationDto
    {
        [StringLength(maximumLength: 14)]
        public string EaringId { get; set; }
        [DataType(DataType.Date)]
        public DateTime InseminationDate { get; set; }
        [StringLength(maximumLength: 50)]
        public string Semen { get; set; }
        [Display(Name = "Treatment number")]
        public int TreatmenNumber { get; set; }
    }
}
