using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Features.Tickets.Commands.CreateTicket;

public class CreateTicketResponse
{
    public string Id { get; set; } = string.Empty;
    public string Status { get; set; } = "Open";
    public DateTime CreatedAt { get; set; }
}
