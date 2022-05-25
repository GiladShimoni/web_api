using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class sessionController : ControllerBase
    {

        [HttpPost]
        public void Login(string id)
        {
            HttpContext.Session.SetString("id", id);
        }

        [HttpGet]
        public User? getOwner() {
            string? id = HttpContext.Session.GetString("id");
            if(id == null)
                return null;
            return new UserService().GetUser(id);
        }
    }
}
