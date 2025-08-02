using MediatR;
using OfflineTicketingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Features.Tickets.Commands.CreateTicket;

public class CreateTicketCommand : IRequest<CreateTicketResponse>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketPriority Priority { get; set; } 
}
