using MediatR;
using OfflineTicketingSystem.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Features.Tickets.Commands.UpdateTicket
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, bool>
    {
        private readonly ITicketRepository _repository;
        private readonly IUserService _userService;

        public UpdateTicketCommandHandler(ITicketRepository repository, IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<bool> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByIdAsync(request.Id);
            if (ticket == null)
                return false;

            ticket.Status = request.Status;
            ticket.AssignedToUserId = request.AssignedToUserId;
            ticket.UpdatedAt= DateTime.UtcNow;

            await _repository.UpdateAsync(ticket);
            return true;
        }
    }
}
