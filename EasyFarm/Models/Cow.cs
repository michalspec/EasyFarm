using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFarm.Models
{
    public class Cow
    {
        [Key]
        [StringLength(maximumLength:14)]
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
        public DateTime LastCalving{ get; set; }
        [DataType(DataType.Date)]
        public DateTime InseminationDate { get; set; }
        [StringLength(maximumLength: 50)]
        public string Semen { get; set; }
        public int TreatmenNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime USG { get; set; }
        [DataType(DataType.Date)]
        public DateTime SuccessfullInsemination { get; set; }
        public int MilkingDays { get; set; }
        public Status Status { get; set; }
        public int DaysToCalving { get; set; }
        [StringLength(maximumLength: 255)]
        public string Comments { get; set; }
        public bool IsAlive { get; set; }
        public int MilksEfficiency { get; set; }
    }
}
