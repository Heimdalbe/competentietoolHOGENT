using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.Identities;
using CompetentieTool.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CompetentieTool.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult WijzigGegevens(int id)
        {
            ApplicationUser user = _userRepository.GetById(id);
            if (user == null)
                return NotFound();

            return View(new ProfielViewModel(user));
        }
        [HttpPost]
        
        public IActionResult WijzigGegevens(int id, ProfielViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = _userRepository.GetById(id);
                    user.wijzigGegevens(viewmodel);
                    _userRepository.SaveChanges();
                    return View("Bevestiging");
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