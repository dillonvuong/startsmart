using Microsoft.AspNetCore.Mvc;
using StartSmart.Models;
using StartSmart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;

        public HomeController( UserRepository userRepository )
        {
            _userRepository = userRepository;
        }
        public ViewResult Index()
        {
            var model =_userRepository.GetAllUsers();
            return View(model);
        }

        public ViewResult Details( int? id )
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                User = _userRepository.GetUser( id??1 ),
                PageTitle = "User Details"

            };
            return View( homeDetailsViewModel );
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( User user )
        {
            if( ModelState.IsValid )
            {
                User newUser = _userRepository.Add(user);
                return RedirectToAction("details", new { id = newUser.Id });
            }

            return View();     
        }


    }
}
