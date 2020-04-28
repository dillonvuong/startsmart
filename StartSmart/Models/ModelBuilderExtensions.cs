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
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Kumayl",
                    Major = Major.ComputerScience,
                    Email = "kumayla@uci.edu"
                },
                new User
                {
                    Id = 2,
                    Name = "Dillon",
                    Major = Major.ComputerScience,
                    Email = "dillon@uci.edu"
                }

               );
        }
    }
}
