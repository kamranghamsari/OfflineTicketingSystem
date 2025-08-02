using OfflineTicketingSystem.Domain.Enums;

namespace OfflineTicketingSystem.Application.Features.Tickets.Models;

public class TicketDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TicketStatus Status { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; } 
}
