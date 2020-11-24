using EasyFarm.Data;
using EasyFarm.DTO;
using EasyFarm.IService;
using EasyFarm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFarm.Services
{
    public class CowsRepo : ICowsRepo
    {
        private readonly AppDbContext _context;

        public CowsRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddCow(Cow cow)
        {
            if(cow == null)
            {
                throw new ArgumentNullException(nameof(cow));
            }
            /*
             * Check if cow.Mother exist in Database
             */
            await _context.Cows.AddAsync(cow);
        }

        public async Task<Cow> GetCow(string id)
        {
            var cow = await _context.Cows.FirstOrDefaultAsync(x => x.EaringId == id);

            if(cow == null)
            {
                throw new Exception("Record not found");
            }
            return cow;

        }

        public async Task<ICollection<Cow>> GetHerd()
        {
            return await _context.Cows.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
