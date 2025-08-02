using OfflineTicketingSystem.Domain.Common;
using OfflineTicketingSystem.Domain.Enums;

namespace OfflineTicketingSystem.Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
}
