using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IContactService
    {
        List<Contact> getContacts(string owner);
        Contact? GetContact(string owner,string id);

        void editContact(string owner, string id, Contact contact);

        void deleteContact(string owner, string id);

        //void addContact(string owner, string id);

        void addContact(string owner, Contact contact);

        int getMsgId(string owner, string id);

        void updateContact(string owner, string id);

       

    }
}
