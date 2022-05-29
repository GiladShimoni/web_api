using Microsoft.AspNetCore.SignalR;
namespace web_api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string idTo, string connectedUser)
        {
            await Clients.All.SendAsync("recieveMessage", idTo, connectedUser);
        }

        public async Task AddContact(string idAdd,string connectedUser)
        {
            await Clients.All.SendAsync("newContact", idAdd, connectedUser);

        }
    }
}
