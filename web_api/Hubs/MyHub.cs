using Microsoft.AspNetCore.SignalR;
namespace web_api.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessage(string id, string content, string connectedUser)
        {
            await Clients.All.SendAsync("recieveMessage", id, content, connectedUser);
        }

        public async Task AddContact(string id, string username,string server,string connectedUser)
        {
            await Clients.All.SendAsync("newContact", id, username, server, connectedUser);

        }
    }
}
