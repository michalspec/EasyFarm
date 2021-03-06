﻿using AutoMapper;
using EasyFarm.DTO;
using EasyFarm.IService;
using EasyFarm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFarm.Controllers
{
    public class MainPanelController : Controller
    {
        private readonly ICowsRepo _repo;
        private readonly IMapper _mapper;

        public MainPanelController(ICowsRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddCalf()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCalf(AddCalfDto model)
        {
            if(ModelState.IsValid)
            {
                var cow = _mapper.Map<Cow>(model);
                await _repo.AddCow(cow);
                await _repo.SaveChangesAsync();

                return RedirectToAction("Details", new { id = cow.EaringId});
            }
            return View(model);
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Details(string id)
        {
            var cow = await _repo.GetCow(id);

            return View(cow);
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> DetailsForAll()
        {
            var herd = await _repo.GetHerd();

            return View(herd);
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> AddInsemination()
        {
            var herd = await _repo.GetHerd();
            ViewBag.Herd = herd;
            ViewData["Herd"] = herd;

            return View();
        }

        [HttpPost, Authorize]
        public async Task<IActionResult>AddInsemination(InseminationDto model)
        {
            

            if(ModelState.IsValid)
            {
                var cow = await _repo.GetCow(model.EaringId);

                if (cow != null)
                {
                    _mapper.Map(model, cow);

                    await _repo.SaveChangesAsync();

                    return RedirectToAction("Details", new { id = cow.EaringId });
                }
            }

            return View(model);
        }


    }
}
