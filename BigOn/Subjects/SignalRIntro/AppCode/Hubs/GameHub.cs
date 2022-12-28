using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRIntro.AppCode.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendPosition(string positionJson)
        {
            await Clients.Others.SendAsync("ReceivePosition", positionJson);
        }
    }
}
