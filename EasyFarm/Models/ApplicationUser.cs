using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFarm.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
