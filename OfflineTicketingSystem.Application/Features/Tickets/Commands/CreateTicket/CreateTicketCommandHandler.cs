using MediatR;
using OfflineTicketingSystem.Application.Common.Interfaces;
using OfflineTicketingSystem.Domain.Entities;
using OfflineTicketingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Features.Tickets.Commands.CreateTicket;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, CreateTicketResponse>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUserService _userService;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository, IUserService userService)
    {
        _ticketRepository = ticketRepository;
        _userService = userService;
    }

    public async Task<CreateTicketResponse> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            Title = request.Title,
            Description = request.Description,
            CreatedByUserId = _userService.UserId,
            Priority = request.Priority,
        };

        await _ticketRepository.CreateAsync(ticket);

        return new CreateTicketResponse
        {
            Id = ticket.Id.ToString(),
            Status = ticket.Status.ToString(),
            CreatedAt = ticket.CreatedAt
        };
    }
}
