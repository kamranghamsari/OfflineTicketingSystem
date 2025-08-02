using MediatR;

namespace OfflineTicketingSystem.Application.Features.Auth.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
