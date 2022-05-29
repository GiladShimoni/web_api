#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain;
using Services;
using Reposetory;

namespace server
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService services = new UserService();


        // GET: Users
        [HttpGet]
        public List<User> Index()
        {
            return services.GetUsers();
        }

        // GET: Users/Details/5
        [HttpGet("{id}")]
        public User Details(string id)
        {
            return services.GetUser(id);
        }

/*        [HttpGet("{name}")]
        public User DetailsByName(string name)
        {
            return services.GetUserByName(name);
        }*/


        [HttpPost]
        public void Create(string id, string name, string? profile, string? password)
        {
            User user = new User();
            user.id = id;
            user.name = name;
            user.profiePic = profile;
            user.password = password;
            user.server = "localhost";
            user.Contacts = new List<Contact>();
            services.AddUser(user);
        }


        [HttpPut]
        public void Edit(string id, string? name, string? profilePic, string? password)
        {

            if (name != null)
                services.EditName(id, name);

            if (password != null)
                services.EditPassword(id, password);

            if (profilePic != null) ;
                services.EditProfile(id, profilePic);

        }




        [HttpDelete]
        public void Remove(string id)
        {
            services.Remove(id);
        }


        [HttpPost("Register")]
        public string Register(string id, string name, string password, string profilePic) {
            User? usr = services.GetUser(id);
            if (usr != null)
                return "Name is Taken, please choose a diffrent one";

            if (profilePic == null)
                profilePic = "desult user.png";

            User user = new User() { id = id, name = name, password = password, profiePic = profilePic, Contacts = new List<Contact>(), server = "localhost"};
            services.AddUser(user);
            return "Success";
        }







    }
}
