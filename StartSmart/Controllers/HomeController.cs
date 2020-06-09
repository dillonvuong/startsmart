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


        [HttpGet]
        public ViewResult Details( string? id )
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                User = _userRepository.GetUser( id?? "4c0cd7d3-735d-4962-a7b1-2fa524d4d4e7" ),
                PageTitle = "User Details"

            };
            return View( homeDetailsViewModel );
        }

        /*[HttpGet]
        public ViewResult Create()
        {

            return View();
        }*/

        [HttpGet]
        public ViewResult LoginPage()
        {

            return View();
        }

        [HttpGet]
        public ViewResult Events( string? id )
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                User = _userRepository.GetUser(id ?? "4c0cd7d3-735d-4962-a7b1-2fa524d4d4e7"),
                PageTitle = "User Events"

            };
            return View(homeDetailsViewModel);

        }

        [HttpGet]
        public ViewResult Edit( string id )
        {
            ApplicationUser user = _userRepository.GetUser(id);
            System.Diagnostics.Debug.WriteLine(user.Id);
            UserEditViewModel userEditViewModel = new UserEditViewModel
            {
                
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                MBTI = user.MBTI,
                Interests = user.Interests

            };

            return View( userEditViewModel );
        }

        [HttpPost]
        public IActionResult Edit( UserEditViewModel model )
        {
            System.Diagnostics.Debug.WriteLine(model.MBTI);

            ApplicationUser user = _userRepository.GetUser(model.Id);

            user.UserName = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.MBTI = model.MBTI;
            user.Interests = model.Interests;

            _userRepository.Update( user );

            return RedirectToAction( "details", new { id = user.Id });
            
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
        public ViewResult WelcomePage( string? id )
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                User = _userRepository.GetUser(id ?? "4c0cd7d3-735d-4962-a7b1-2fa524d4d4e7" ),
                PageTitle = "User Details"

            };
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Learn(string? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                User = _userRepository.GetUser(id ?? "4c0cd7d3-735d-4962-a7b1-2fa524d4d4e7"),
                PageTitle = "User Details"

            };
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult SignUpConfirmation(string? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                User = _userRepository.GetUser(id ?? "4c0cd7d3-735d-4962-a7b1-2fa524d4d4e7" ),
                PageTitle = "Welcome to StartSmart"

            };
            return View(homeDetailsViewModel);
        }

        /*[HttpPost]
        public IActionResult Create( UserCreateViewModel model )
        {
            if( ModelState.IsValid )
            {
                string uniqueFileName = ProccessUploadedFile(model);
               
                User newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    MBTI = model.MBTI,
                    Interests = model.Interests,
                    ProfilePicture = uniqueFileName,
                    Password = model.Password
                  
                };

                _userRepository.Add(newUser);

                return RedirectToAction("SignUpConfirmation", new { id = newUser.Id });
            }

            return View();     
        }*/


    }
}
