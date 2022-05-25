using Microsoft.AspNetCore.SignalR;
namespace web_api.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessage(string value)
        {
            await Clients.All.SendAsync("recieveMessage", value);
        }

        public async Task AddContact(string value)
        {
            await Clients.All.SendAsync("newContact", value);

        }
    }
}
