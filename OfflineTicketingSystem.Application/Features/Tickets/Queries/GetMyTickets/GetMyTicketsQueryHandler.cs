using AutoMapper;
using MediatR;
using OfflineTicketingSystem.Application.Common.Interfaces;
using OfflineTicketingSystem.Application.Features.Tickets.Models;
using OfflineTicketingSystem.Application.Features.Tickets.Queries.GetMyTickets;

namespace OfflineTicketingSystem.Application.Features.Tickets.Queries.GetAllTickets;

public class GetMyTicketsQueryHandler : IRequestHandler<GetMyTicketsQuery, List<TicketDto>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetMyTicketsQueryHandler(ITicketRepository ticketRepository, IMapper mapper, IUserService userService)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<List<TicketDto>> Handle(GetMyTicketsQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _ticketRepository.GetByUserIdAsync(_userService.UserId);
        return _mapper.Map<List<TicketDto>>(tickets);
    }
}
