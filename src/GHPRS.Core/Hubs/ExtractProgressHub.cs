using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace GHPRS.Core.Hubs;

public class ExtractProgressHub : Hub
{
    public async Task Update(ExtractProgress progress)
    {
        await Clients.All.SendAsync("Progress", progress);
    }
}