using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFarm.Models
{
    public class Cow
    {
        [Key]
        [StringLength(maximumLength:14)]
        [Display(Name = "Earing number")]
        public string EaringId { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [StringLength(maximumLength: 50)]
        public string Father { get; set; }
        public Cow Mother { get; set; }
        public int Lactation { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Last calving")]
        public DateTime LastCalving{ get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Insemination date")]
        public DateTime InseminationDate { get; set; }
        [StringLength(maximumLength: 50)]
        public string Semen { get; set; }
        [Display(Name = "Treatment number")]
        public int TreatmenNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime USG { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Succesfull insemination")]
        public DateTime SuccessfullInsemination { get; set; }
        [Display(Name = "Milking days")]
        public int MilkingDays { get; set; }
        public Status Status { get; set; }
        [Display(Name = "Days to calving")]
        public int DaysToCalving { get; set; }
        [StringLength(maximumLength: 255)]
        public string Comments { get; set; }
        [Display(Name = "Is alive")]
        public bool IsAlive { get; set; }
        [Display(Name = "Milk Efficiency")]
        public int MilksEfficiency { get; set; }
    }
}
