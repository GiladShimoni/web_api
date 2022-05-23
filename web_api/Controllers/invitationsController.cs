using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;

namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class invitationsController : ControllerBase
    { 
        private IContactService _contactService = new ContactService();


        [HttpPost]
        public void Invite(string from, string to, string server)
        {
            Contact contact = new Contact() { id = from, name = from, server = server, messages = new List<message>(), last = null, lastdate = null };
            _contactService.addContact(to, contact);
        }

       
    }
}
