using Microsoft.AspNetCore.Identity;

namespace CineClub.Services;

public interface IUserHelperService
{
    Task<string> GetUserNameAsync(string? userId);
    Task<bool> IsOwnerAsync(string? userId);
}

public class UserHelperService : IUserHelperService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserHelperService(UserManager<IdentityUser> userManager,
                             IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string> GetUserNameAsync(string? userId)
    {
        if (string.IsNullOrEmpty(userId))
            return "User not found";

        var user = await _userManager.FindByIdAsync(userId);
        return user?.UserName ?? "Unknown User";
    }

    public async Task<bool> IsOwnerAsync(string? userId)
    {
        if (!_httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated)
            return false;

        var currentUserId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
        return currentUserId == userId;
    }
}

