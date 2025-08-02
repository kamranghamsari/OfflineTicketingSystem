using AutoMapper;
using MediatR;
using OfflineTicketingSystem.Application.Common.Interfaces;
using OfflineTicketingSystem.Application.Features.Tickets.Models;

namespace OfflineTicketingSystem.Application.Features.Tickets.Queries.GetAllTickets;

public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, List<TicketDto>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public GetAllTicketsQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task<List<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _ticketRepository.GetAllAsync();
        return _mapper.Map<List<TicketDto>>(tickets);
    }
}
