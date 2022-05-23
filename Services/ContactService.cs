using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reposetory;

namespace Services
{
    public class ContactService : IContactService
    {
        
        
        private UserService _userService = new UserService();

        public void addContact(string owner, Contact contact) {
            foreach (User usr in DB.Users)
            {
                if (usr.id == owner)
                {
                    usr.Contacts.Add(contact);
                    return;
                }
            }
        }

        /*public void addContact(string owner, string id)
        {
            Contact contact = new Contact();
            
            //create new contact:
            User user = _userService.GetUser(id);
            if (user == null)
                return;
            contact.id = id;
            contact.server = user.server;
            contact.name = user.name;
            contact.messages = new List<message> ();
            
            
            foreach (User usr in DB.Users) {
                if (usr.id == owner) { 
                   usr.Contacts.Add(contact);
                   return;
                }
            }
        }*/

        

        public void deleteContact(string owner, string id)
        {
            foreach (User usr in DB.Users)
            {
                if (usr.id == owner)
                {
                    foreach (Contact contact in usr.Contacts) {
                        if (contact.id == id) 
                        {
                            usr.Contacts.Remove(contact);
                            return;
                        }
                        
                    }
                    return;
                }
            }
        }

        public void editContact(string owner, string id, Contact contact)
        {
            foreach (User usr in DB.Users)
            {
                if (usr.id == owner)
                {
                    foreach (Contact contact1 in usr.Contacts)
                    {
                        if (contact.id == id) 
                        {
                            contact1.name = contact.name;
                            contact1.server = contact.server;
                            return;
                        }
                    }
                    return;
                }
            }

        }

        public Contact? GetContact(string owner, string id)
        {
            foreach (User usr in DB.Users)
            {
                if (usr.id == owner)
                {
                    foreach (Contact contact in usr.Contacts)
                    {
                        if (contact.id == id)
                        {
                            return contact;
                        }

                    }
                }
            }

            return null;
        }

        public List<Contact> getContacts(string owner)
        {
            return _userService.GetUser(owner).Contacts;
        }

        public int getMsgId(string owner, string id) {
            foreach (User usr in DB.Users)
            {
                if (usr.id == owner)
                {
                    foreach (Contact contact in usr.Contacts)
                    {
                        if (contact.id == id)
                        {
                            if (contact.messages.Count == 0)
                                return 0;
                            return contact.messages.OrderByDescending(m => m.created).First().id + 1;
                        }

                    }
                }
            }
            return 0;
        }


        public void updateContact(string owner, string id) {
            foreach (User usr in DB.Users)
            {
                if (usr.id == owner)
                {
                    foreach (Contact contact in usr.Contacts)
                    {
                        if (contact.id == id)
                        {
                            if (contact.messages.Count == 0) {
                                contact.lastdate = null;
                                contact.last = null;
                                return;
                            
                            }
                            message msg = contact.messages.OrderByDescending(m => m.created).First();
                            contact.last = msg.content;
                            contact.lastdate = msg.created;
                            return;
                        }

                    }
                }
            }
        }

    }
}
