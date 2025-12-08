using Microsoft.AspNetCore.SignalR;

public class ReviewsHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        //create http context obj
        // The low-level WebSocket is there, but SignalR hides it; we just see the HTTP context of the initial handshake.
        var httpContext = Context.GetHttpContext();
        
        //get movie id to detect which movie we are working on 
        var movieId = httpContext.Request.Query["movieId"];

        //add connection to group called such movie-1, movie-2, ...
        await Groups.AddToGroupAsync(Context.ConnectionId, $"movie-{movieId}");

        await base.OnConnectedAsync();
    }
}
