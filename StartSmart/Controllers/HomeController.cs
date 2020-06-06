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
        public ViewResult Edit( int id )
        {
            User user = _userRepository.GetUser(id);
            UserEditViewModel userEditViewModel = new UserEditViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Major = user.Major,
                Bio = user.Bio

            };

            return View( userEditViewModel );
        }

        [HttpPost]
        public IActionResult Edit( UserEditViewModel model )
        {
            System.Diagnostics.Debug.WriteLine(model.Major);
            
            User user = _userRepository.GetUser(model.Id);
                
            user.Name = model.Name;
            user.Email = model.Email;
            user.Major = model.Major;
            user.Bio = model.Bio;

            _userRepository.Update( user );

            return RedirectToAction( "details" );
            
        }

        private string ProccessUploadedFile(UserCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.ProfilePicture != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.ProfilePicture.CopyTo(new FileStream(filePath, FileMode.Create));

            }

            return uniqueFileName;
        }

        [HttpGet]
        public ViewResult WelcomePage( int? id )
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                User = _userRepository.GetUser(id ?? 1),
                PageTitle = "User Details"

            };
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult SignUpConfirmation(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                User = _userRepository.GetUser(id ?? 1),
                PageTitle = "Welcome to StartSmart"

            };
            return View(homeDetailsViewModel);
        }

        [HttpPost]
        public IActionResult Create( UserCreateViewModel model )
        {
            if( ModelState.IsValid )
            {
                string uniqueFileName = ProccessUploadedFile(model);
               
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
