﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartSmart.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string MBTI { get; set; }

        public string Interests { get; set; }

        [Required]
        [DataType( DataType.Password )]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display( Name = "Confirm password" )]
        [Compare("Password",
                    ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
