using Microsoft.AspNetCore.Mvc;

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
    }
}
