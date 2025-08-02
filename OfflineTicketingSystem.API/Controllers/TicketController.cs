using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfflineTicketingSystem.Application.Features.Tickets.Commands.CreateTicket;
using OfflineTicketingSystem.Application.Features.Tickets.Commands.UpdateTicket;
using OfflineTicketingSystem.Application.Features.Tickets.Queries.GetAllTickets;
using OfflineTicketingSystem.Application.Features.Tickets.Queries.GetMyTickets;
using OfflineTicketingSystem.Application.Features.Tickets.Queries.GetStats;
using System.Security.Claims;

namespace OfflineTicketingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand command)
        {
            var ticketId = await _mediator.Send(command);
            return Ok(new { id = ticketId });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateTicket([FromBody] UpdateTicketCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("All")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _mediator.Send(new GetAllTicketsQuery());
            return Ok(tickets);
        }

        [HttpGet("my")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetMyTickets()
        {
            var tickets = await _mediator.Send(new GetMyTicketsQuery());
            return Ok(tickets);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var result = await _mediator.Send(new GetStatsQuery());
            return Ok(result);
        }

    }
}
