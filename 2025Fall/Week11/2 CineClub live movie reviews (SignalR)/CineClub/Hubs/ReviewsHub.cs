using Microsoft.AspNetCore.SignalR;

public class ReviewsHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var movieId = httpContext.Request.Query["movieId"];

        await Groups.AddToGroupAsync(Context.ConnectionId, $"movie-{movieId}");

        await base.OnConnectedAsync();
    }
}
