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
                    Major = "Computer Science",
                    Email = "kumayla@uci.edu",
                    Password = "123456"
                },
                new User
                {
                    Id = 2,
                    Name = "Dillon",
                    Major = "Computer Science",
                    Email = "dillon@uci.edu",
                    Password = "4567"
                }

               );
        }
    }
}
