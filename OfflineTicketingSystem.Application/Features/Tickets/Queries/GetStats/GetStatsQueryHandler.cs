using MediatR;
using OfflineTicketingSystem.Application.Common.Interfaces;
using OfflineTicketingSystem.Application.Features.Tickets.Models;
using OfflineTicketingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Features.Tickets.Queries.GetStats;

public class GetStatsQueryHandler : IRequestHandler<GetStatsQuery, TicketStatsDto>
{
    private readonly ITicketRepository _ticketRepository;

    public GetStatsQueryHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<TicketStatsDto> Handle(GetStatsQuery request, CancellationToken cancellationToken)
    {
        var allTickets = await _ticketRepository.GetAllAsync();

        return new TicketStatsDto
        {
            Total = allTickets.Count,
            Open = allTickets.Count(t => t.Status == TicketStatus.Open),
            InProgress = allTickets.Count(t => t.Status == TicketStatus.InProgress),
            Closed = allTickets.Count(t => t.Status == TicketStatus.Closed)
        };
    }
}
