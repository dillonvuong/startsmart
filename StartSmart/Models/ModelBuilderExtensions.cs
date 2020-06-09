using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSmart.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed( this ModelBuilder modelBuilder  )
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "2",
                    FirstName = "Kumayl",
                    LastName = "Abbas",
                    MBTI = "INFP",
                    Email = "kumayla@uci.edu",
                    Interests = "Software engineering, Front-end technology"
                }
               );
        }
    }
}
