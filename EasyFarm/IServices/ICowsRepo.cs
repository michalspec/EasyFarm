using EasyFarm.DTO;
using EasyFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFarm.IService
{
    public interface ICowsRepo
    {
        Task<bool> SaveChangesAsync();
        Task AddCow(Cow cow);

        Task<Cow> GetCow(string id);

    }
}
