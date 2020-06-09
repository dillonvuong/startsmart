using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSmart.Models
{
    public class SQLUserRepository : UserRepository
    {
        private readonly AppDbContext context;
        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ApplicationUser Add(ApplicationUser user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;

        }

        public ApplicationUser Delete(int id)
        {
            ApplicationUser user = context.AspNetUsers.Find(id);
            if( user != null )
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return context.AspNetUsers;
        }

        public ApplicationUser GetUser(string id)
        {
            return context.AspNetUsers.Find( id );
        }

        public ApplicationUser Update(ApplicationUser userChanges)
        {
            var user = context.Users.Attach( userChanges );
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return userChanges;
        }
    }
}