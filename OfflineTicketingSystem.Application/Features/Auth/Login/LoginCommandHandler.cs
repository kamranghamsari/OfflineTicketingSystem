using MediatR;
using OfflineTicketingSystem.Application.Features.Auth.Login;
using OfflineTicketingSystem.Domain.Enums;
using OfflineTicketingSystem.Domain.Entities;
using OfflineTicketingSystem.Application.Common.Interfaces;
using BCrypt.Net;


namespace OfflineTicketingSystem.Application.Features.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            var token = _jwtService.GenerateToken(user);

            return new LoginResponse
            {
                Token = token,
                FullName = user.FullName,
                Role = user.Role.ToString()
            };
        }
    }
}
