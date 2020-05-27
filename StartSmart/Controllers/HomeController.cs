using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StartSmart.Models;
using StartSmart.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StartSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController( UserRepository userRepository, IWebHostEnvironment hostingEnvironment)
        {
            _userRepository = userRepository;
            this.hostingEnvironment = hostingEnvironment;
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

        [HttpGet]
        public ViewResult WelcomePage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( UserCreateViewModel model )
        {
            if( ModelState.IsValid )
            {
                string uniqueFileName = null;
                if( model.ProfilePicture != null )
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
                    string filePath =  Path.Combine(uploadsFolder, uniqueFileName);
                    model.ProfilePicture.CopyTo( new FileStream( filePath, FileMode.Create));

                }
                User newUser = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Major = model.Major,
                    Bio = model.Bio,
                    ProfilePicture = uniqueFileName,
                    Password = model.Password
                  
                };

                _userRepository.Add(newUser);

                return RedirectToAction("details", new { id = newUser.Id });
            }

            return View();     
        }


    }
}
