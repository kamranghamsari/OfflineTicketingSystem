﻿namespace OfflineTicketingSystem.Application.Features.Auth.Login;

public class LoginResponse
{
    public string Token { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
}
