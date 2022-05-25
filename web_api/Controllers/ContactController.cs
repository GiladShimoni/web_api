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
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private IContactService services = new ContactService();
        private IMessagesService messages = new MessagesService();


        [HttpGet("{id}")]
        public Contact? GetContact(string id, string connectedUser) {
            /*string? owner = HttpContext.Session.GetString("id");*/
            /*            string? owner = 
                        if (owner == null)
                            return null;*/

            return services.GetContact(connectedUser, id);
        }


        [HttpGet]
        public List<Contact>? GetContacts(string connectedUser)
        {
            /*string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return null;*/

            return services.getContacts(connectedUser);
        }

        [HttpPost]
        public void addContact(string id, string name, string server, string connectedUser) {
            /*string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return;*/


            Contact contact = new Contact();
            contact.id = id;
            contact.name = name;
            contact.server = server;
            contact.messages = new List<message>();
            services.addContact(connectedUser, contact);
        }


        [HttpPut("{id}")]
        public void EditContact(string id, string? name, string? server, string connectedUser) {
            /*            string? owner = HttpContext.Session.GetString("id");
                        if (owner == null)
                            return;*/

            Contact contact = GetContact(id, connectedUser);
            if (contact == null)
                return;

            if (name != null)
                contact.name = name;

            if (server != null)
                contact.server = server;

            services.editContact(connectedUser, id, contact);
        }

        [HttpDelete]
        public void Remove(string id, string connectedUser)
        {
            /*            string? owner = HttpContext.Session.GetString("id");
                        if (owner == null)
                            return;*/

            services.deleteContact(connectedUser, id);
        }



        //*** Messages ***/


        [HttpGet("{id}/messages")]
        public List<message>? GetMessages(string id, string connectedUser) {
            /*            string? owner = HttpContext.Session.GetString("id");
                        if (owner == null)
                            return null;*/

            return messages.GetMessages(connectedUser, id);
        }

        [HttpPost("{id}/messages")]
        public void Send(string id, string content, string connectedUser) {
            /*            string? owner = HttpContext.Session.GetString("id");
                        if (owner == null)
                            return;*/

            int msgId = services.getMsgId(connectedUser, id);
            message msg = new message { id = msgId, content = content, created = DateTime.Now, sent = true };
            messages.SendMessage(connectedUser, id, msg);

        }


        [HttpGet("{id}/messages/{msgId}")]
        public message? GetMessage(string id, int msgId, string connectedUser)
        {
            /*            string? owner = HttpContext.Session.GetString("id");
                        if (owner == null)
                            return null;*/

            return messages.GetMessage(connectedUser, id, msgId);
        }

        [HttpPut("{id}/messages/{msgId}")]
        public void Edit(string id, int msgId, string content, string connectedUser)
        {
            /*            string? owner = HttpContext.Session.GetString("id");
                        if (owner == null)
                            return;*/

            messages.Edit(connectedUser, id, msgId, content);
            services.updateContact(connectedUser, id);

        }

        [HttpDelete("{id}/messages/{msgId}")]
        public void Delete(string id, int msgId, string connectedUser) {
            /*            string? owner = HttpContext.Session.GetString("id");
                        if (owner == null)
                            return;*/

            messages.Delete(connectedUser, id, msgId);
            services.updateContact(connectedUser, id);
        }



        [HttpPost("connect")]
        public List<Contact>? Connect(string id, string name, string server, string connectedUser)
        {
            addContact(id, name, server, connectedUser);
            return GetContacts(connectedUser);
        }

    }
}
/*
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
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private IContactService services = new ContactService();
        private IMessagesService messages = new MessagesService();


        [HttpGet("{id}")]
        public Contact? GetContact(string id)
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return null;

            return services.GetContact(owner, id);
        }


        [HttpGet]
        public List<Contact>? GetContacts()
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return null;

            return services.getContacts(owner);
        }

        [HttpPost]
        public void addContact(string id, string name, string server)
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return;


            Contact contact = new Contact();
            contact.id = id;
            contact.name = name;
            contact.server = server;
            contact.messages = new List<message>();
            services.addContact(owner, contact);
        }


        [HttpPut("{id}")]
        public void EditContact(string id, string? name, string? server)
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return;

            Contact contact = GetContact(id);
            if (contact == null)
                return;

            if (name != null)
                contact.name = name;

            if (server != null)
                contact.server = server;

            services.editContact(owner, id, contact);
        }

        [HttpDelete]
        public void Remove(string id)
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return;

            services.deleteContact(owner, id);
        }



        //*** Messages ***/


        /*[HttpGet("{id}/messages")]
        public List<message>? GetMessages(string id)
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return null;

            return messages.GetMessages(owner, id);
        }

        [HttpPost("{id}/messages")]
        public void Send(string id, string content)
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return;

            int msgId = services.getMsgId(owner, id);
            message msg = new message { id = msgId, content = content, created = DateTime.Now, sent = true };
            messages.SendMessage(owner, id, msg);

        }


        [HttpGet("{id}/messages/{msgId}")]
        public message? GetMessage(string id, int msgId)
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return null;

            return messages.GetMessage(owner, id, msgId);
        }

        [HttpPut("{id}/messages/{msgId}")]
        public void Edit(string id, int msgId, string content)
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return;

            messages.Edit(owner, id, msgId, content);
            services.updateContact(owner, id);

        }

        [HttpDelete("{id}/messages/{msgId}")]
        public void Delete(string id, int msgId)
        {
            string? owner = HttpContext.Session.GetString("id");
            if (owner == null)
                return;

            messages.Delete(owner, id, msgId);
            services.updateContact(owner, id);
        }



        [HttpPost("connect")]
        public List<Contact>? Connect(string id, string name, string server)
        {
            addContact(id, name, server);
            return GetContacts();
        }

    }
}*/
