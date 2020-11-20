using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFarm.Models
{
    public enum Status
    { 
        Sync = 0,
        LessThan90 = 1,
        InCalf = 2,
        Treatment = 3,
        Waiting = 4,
        Inseminated =5
    }
}
