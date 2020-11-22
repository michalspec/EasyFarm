using AutoMapper;
using EasyFarm.DTO;
using EasyFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFarm.Profiles
{
    public class CowProfiles : Profile
    {
        public CowProfiles()
        {
            CreateMap<AddCalfDto, Cow>();
        }
    }
}
