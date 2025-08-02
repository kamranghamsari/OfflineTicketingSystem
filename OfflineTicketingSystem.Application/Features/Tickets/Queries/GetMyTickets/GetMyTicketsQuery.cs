using MediatR;
using OfflineTicketingSystem.Application.Features.Tickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Features.Tickets.Queries.GetMyTickets;

public class GetMyTicketsQuery : IRequest<List<TicketDto>>
{
}
