using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;

namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class sessionController : ControllerBase
    {

        [HttpPost("{id}")]
        public void Login(string id)
        {
            HttpContext.Session.SetString("id", id);
        }


        [HttpGet]
        public User? GetOwner()
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return null;
            return new UserService().GetUser(owner) ;
        }
    }
}
