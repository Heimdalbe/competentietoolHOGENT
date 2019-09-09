using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.Identities;
using CompetentieTool.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompetentieTool.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Gegevens()
        {
            ApplicationUser user = _userManager.FindByEmailAsync(User.Identity.Name).Result;
            if (user == null)
                return NotFound();

            return View(new ProfielViewModel(user));
        }

        [HttpPost]
        public IActionResult Gegevens(ProfielViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = _userManager.FindByEmailAsync(User.Identity.Name).Result;
                    user.wijzigGegevens(viewmodel);
                    _userManager.UpdateAsync(user);
                    TempData["message"] = $"De gegevens zijn succesvol aangepast.";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(viewmodel);
        }
    }
}