using StartSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSmart.ViewModels
{
    public class HomeDetailsViewModel
    {
        public ApplicationUser User { get; set; }
        public string PageTitle { get; set; }
    }
}