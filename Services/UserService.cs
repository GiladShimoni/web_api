using Domain;
using Reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {

        public void AddUser(User user)
        {
            DB.Users.Add(user);   
        }

        public User? GetUser(string id)
        {
            return (DB.Users.Find(x => x.id == id));

        }
       /* public User? GetUserByName(string name)
        {
            return (DB.Users.Find(x => x.name == name));

        }*/

        public List<User> GetUsers()
        {
            return DB.Users.ToList();
        }


        public void EditName(string id, string name)
        {
            foreach (User user in DB.Users)
            {
                if (user.id == id)
                {
                    user.name = name;
                    return;
                }
            }
        }

        public void EditPassword(string id, string password) {
            foreach (User user in DB.Users)
            {
                if (user.id == id)
                {
                    user.password = password;
                    return;
                }
            }
        }

        public void EditProfile(string id, string url) {
            foreach (User user in DB.Users)
            {
                if (user.id == id)
                {
                    user.profiePic = url;
                    return;
                }
            }
        }

          
        public void Remove(string id)
        {
            foreach (User user in DB.Users) {
                if (user.id == id) {
                    DB.Users.Remove(user);
                    return;
                }
            }
        }

    }
}
