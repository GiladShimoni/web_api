using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace Services
{
    public interface IMessagesService
    {
        List<message>? GetMessages(string owner, string id);
        void SendMessage(string owner, string id, message msg);

        message? GetMessage(string owner, string id, int msgId);
        void Edit(string owner, string id, int msgId, string content);

        void Delete(string owner, string id, int msgId);
    }
}
