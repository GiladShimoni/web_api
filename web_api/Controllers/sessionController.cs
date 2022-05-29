using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;

namespace web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class sessionController : ControllerBase
    {

        [HttpGet]
        public string Login(string id)
        {
            HttpContext.Session.SetString("id", id);
            return "added";

        }

       /* [HttpGet]
        public User? GetOwner()
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return null;
            return new UserService().GetUser(owner) ;
        }*/
    }
}
