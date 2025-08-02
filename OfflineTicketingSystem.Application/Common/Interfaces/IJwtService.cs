using OfflineTicketingSystem.Domain.Entities;

namespace OfflineTicketingSystem.Application.Common.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
