using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSmart.Models
{
    public class MockUserRepository : UserRepository
    {
        private List<User> _userList;

        public MockUserRepository()
        {
            _userList = new List<User>()
            {
                new User() { Id = 1, Name = "Kumayl", Email = "kumayla@uci.edu", Major = Major.ComputerScience},
                new User() { Id = 2, Name = "Jeff", Email = "jeff@uci.edu", Major = Major.Informatics },
                new User() { Id = 3, Name = "Jimmy", Email = "jimmy@uci.edu", Major = Major.Economics }

            };
        }

        public User Add(User user)
        {
            user.Id = _userList.Max(u => u.Id) + 1;
            _userList.Add(user);
            return user;
        }

        public User Delete(int id)
        {
            User user = _userList.FirstOrDefault(u => u.Id == id);
            if( user != null )
            {
                _userList.Remove(user);
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userList;
        }

        public User GetUser(int id)
        {
            return _userList.FirstOrDefault( u => u.Id == id);
        }

        public User Update(User userChanges)
        {
            User user = _userList.FirstOrDefault(u => u.Id == userChanges.Id );
            if (user != null)
            {
                user.Name = userChanges.Name;
                user.Email = userChanges.Email;
                user.Major = userChanges.Major;
            }
            return user;
        }
    }
}
