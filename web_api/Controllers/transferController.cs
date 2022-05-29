using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;
namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class transferController : Controller
    {
        private IMessagesService service = new MessagesService();
        
        [HttpPost]
        public void Transfer(string from, string to, string content) 
        {
            message msg = new message()
            {
                id = new ContactService().getMsgId(to, from),
                content = content,
                created = DateTime.Now,
                sent = false
            };
            service.SendMessage(from , to,  msg); 
        }
        
    }
}
