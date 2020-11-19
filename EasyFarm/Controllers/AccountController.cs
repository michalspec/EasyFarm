using EasyFarm.Data;
using EasyFarm.DTO;
using EasyFarm.Models;
using EasyFarm.PasswordHash;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFarm.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IOptions<HashingOptions> _options;
        public AccountController(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
            IOptions<HashingOptions> options)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _options = options;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult>Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var checkUser = await _userManager.FindByEmailAsync(model.Email);

                if (checkUser == null)
                {
                        var user = new ApplicationUser
                        {
                            UserName = model.Email,
                            Email = model.Email,
                            Password = PasswordHasher.Hash(model.Password)
                        };

                    var result = await _userManager.CreateAsync(user, user.Password);

                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email already exists");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
