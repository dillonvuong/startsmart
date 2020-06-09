using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSmart.Models
{
    public interface UserRepository
    {
        ApplicationUser GetUser(string id);
        IEnumerable<ApplicationUser> GetAllUsers();
        ApplicationUser Add(ApplicationUser user);
        ApplicationUser Update(ApplicationUser userChanges);
        ApplicationUser Delete(int id);
    }
}