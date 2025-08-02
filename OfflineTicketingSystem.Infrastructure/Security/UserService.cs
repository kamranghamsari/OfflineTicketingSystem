using Microsoft.AspNetCore.Http;
using OfflineTicketingSystem.Application.Common.Interfaces;
using System.Security.Claims;

namespace OfflineTicketingSystem.Infrastructure.Security;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId =>
        Guid.Parse(_httpContextAccessor.HttpContext!.User!.FindFirst(ClaimTypes.NameIdentifier)!.Value);

    public string Username =>
        _httpContextAccessor.HttpContext?.User?.Identity?.Name!;

    public string Role =>
        _httpContextAccessor.HttpContext!.User!.FindFirst(ClaimTypes.Role)!.Value;
}
