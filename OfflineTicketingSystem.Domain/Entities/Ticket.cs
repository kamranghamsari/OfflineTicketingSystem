using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OfflineTicketingSystem.Domain.Common;
using OfflineTicketingSystem.Domain.Enums;

namespace OfflineTicketingSystem.Domain.Entities;

public class Ticket : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TicketStatus Status { get; set; } = TicketStatus.Open;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;

    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid CreatedByUserId { get; set; }
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid? AssignedToUserId { get; set; }
}
