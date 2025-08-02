using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Common.Interfaces;

public interface IUserService
{
    Guid UserId { get; }
    string Username { get; }
    string Role { get; }
}
