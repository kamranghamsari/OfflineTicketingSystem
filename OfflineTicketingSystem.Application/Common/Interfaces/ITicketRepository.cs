using OfflineTicketingSystem.Domain.Entities;

namespace OfflineTicketingSystem.Application.Common.Interfaces;

public interface ITicketRepository
{
    Task<List<Ticket>> GetAllAsync();
    Task<List<Ticket>> GetByUserIdAsync(Guid userId);
    Task<Ticket?> GetByIdAsync(Guid id);
    Task CreateAsync(Ticket ticket);
    Task UpdateAsync(Ticket ticket);
    Task DeleteAsync(Guid id);
}
