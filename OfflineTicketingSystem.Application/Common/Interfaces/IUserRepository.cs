using OfflineTicketingSystem.Domain.Entities;

namespace OfflineTicketingSystem.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task CreateAsync(User user);
}
