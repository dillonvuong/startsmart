using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartSmart.Models;
using StartSmart.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StartSmart.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserRepository _userRepository;

        public AccountController(UserRepository userRepository, UserManager<ApplicationUser> userManager, 
                                    SignInManager<ApplicationUser> signInManager )
        {
            _userRepository = userRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( RegisterViewModel model )
        {
            if( ModelState.IsValid )
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    MBTI = model.MBTI,
                    Interests = model.Interests
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if( result.Succeeded )
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("SignUpConfirmation", "home", new { id = user.Id });
                }

                foreach( var error in result.Errors )
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View();
        }

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPage( LoginViewModel model )
        {
            if (ModelState.IsValid)
            {
                
                var result = await signInManager.PasswordSignInAsync( model.Email, model.Password,
                                                                        false, false );

                
                var user = signInManager.UserManager.Users.Where(x => x.UserName.Equals(model.Email)).FirstOrDefault();

                System.Diagnostics.Debug.WriteLine( user.Id );

                if ( result.Succeeded )
                { 
                    return RedirectToAction("WelcomePage", "home", new { id = user.Id });
                }

                ModelState.AddModelError(string.Empty, "Invalid login information");
            }

            return View( model );
        }
    }


}
