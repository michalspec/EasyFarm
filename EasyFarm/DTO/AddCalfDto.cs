using EasyFarm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFarm.DTO
{
    public class AddCalfDto

    {
        [Key]
        [StringLength(maximumLength: 14)]
        public string EaringId { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [StringLength(maximumLength: 50)]
        public Cow Mother { get; set; }
    }
}
