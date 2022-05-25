using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reposetory;

namespace Services
{
    public class MessagesService : IMessagesService
    {
        public void Delete(string owner, string id, int msgId)
        {
            foreach (User user in DB.Users)
            {
                if (user.id == owner)
                {
                    foreach (Contact contact in user.Contacts)
                    {
                        if (contact.id == id)
                        {
                            foreach (message msg in contact.messages)
                                if (msg.id == msgId) {
                                    contact.messages.Remove(msg);
                                    return;
                                }
                        }
                    }
                }
            }
        }

        public void Edit(string owner, string id, int msgId, string content)
        {
            foreach (User user in DB.Users)
            {
                if (user.id == owner)
                {
                    foreach (Contact contact in user.Contacts)
                    {
                        if (contact.id == id)
                        {
                            foreach (message msg in contact.messages)
                                if (msg.id == msgId)
                                {
                                    msg.content = content;
                                    return;
                                }
                        }
                    }
                }
            }
        }

        public message? GetMessage(string owner, string id, int msgId)
        {
            foreach (User user in DB.Users)
            {
                if (user.id == owner)
                {
                    foreach (Contact contact in user.Contacts)
                    {
                        if (contact.id == id)
                        {
                            foreach (message msg in contact.messages)
                                if (msg.id == msgId)
                                {
                                    return msg;
                                }
                        }
                    }
                }
            }
            return null;
        }

        public List<message>? GetMessages(string owner, string id)
        {
            foreach (User user in DB.Users)
            {
                if (user.id == owner)
                {
                    foreach (Contact contact in user.Contacts)
                    {
                        if (contact.id == id)
                            return contact.messages;
                    }
                }
            }
            return null;
        }



        public void SendMessage(string owner, string id, message msg)
        {
            foreach (User user in DB.Users)
            {
                if (user.id == owner)
                {
                    foreach (Contact contact in user.Contacts)
                    {
                        if (contact.id == id)
                        {
                            contact.messages.Add(msg);
                            contact.lastdate = msg.created;
                            contact.last = msg.content;
                            DB.Messages.Add(new rMessages() { msg = msg.content, reciever = contact.id, sender = owner, time = msg.created });
                        }
                    }
                }
            }

        }
    }
}
