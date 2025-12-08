using Microsoft.AspNetCore.SignalR;

namespace CineClub.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            // broadcast the message to all connected clients
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
