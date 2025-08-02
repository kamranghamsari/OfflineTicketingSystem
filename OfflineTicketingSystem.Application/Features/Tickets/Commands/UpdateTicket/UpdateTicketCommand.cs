using MediatR;
using OfflineTicketingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Features.Tickets.Commands.UpdateTicket;

public class UpdateTicketCommand : IRequest<bool>
{
    public Guid Id { get; set; } 
    public TicketStatus Status { get; set; }
    public Guid AssignedToUserId { get; set; }
}
