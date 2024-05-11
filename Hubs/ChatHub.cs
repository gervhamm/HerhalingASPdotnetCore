using Microsoft.AspNetCore.SignalR;

namespace HerhalingASPdotnetCore.Hubs
{
    /// <summary>
    /// The Hub class is the main class that manages the connection between the client and the server.
    /// ChatHub Inherits from the SignalR Hub class.
    /// </summary>
    public class ChatHub : Hub
    {
        /// <summary>
        /// The SendMessage method is called by the client to send a message to all connected clients.
        /// </summary>
        /// <param name="user"> The user that sends the message.</param>
        /// <param name="message"> The message that is sent.</param>
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
