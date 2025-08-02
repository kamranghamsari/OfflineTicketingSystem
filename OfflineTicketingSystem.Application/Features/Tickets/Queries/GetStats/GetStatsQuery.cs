using MediatR;
using OfflineTicketingSystem.Application.Features.Tickets.Models;

namespace OfflineTicketingSystem.Application.Features.Tickets.Queries.GetStats;

public class GetStatsQuery : IRequest<TicketStatsDto>
{
}
