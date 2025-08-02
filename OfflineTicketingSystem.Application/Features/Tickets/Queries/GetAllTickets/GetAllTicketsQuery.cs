using MediatR;
using OfflineTicketingSystem.Application.Features.Tickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Features.Tickets.Queries.GetAllTickets
{
    public class GetAllTicketsQuery : IRequest<List<TicketDto>>;
}
