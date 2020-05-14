using Microsoft.AspNetCore.Http;
using StartSmart.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartSmart.ViewModels
{
    public class UserCreateViewModel
    {

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }
        public string Major { get; set; }

        public IFormFile ProfilePicture { get; set; }

        public string Bio { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
