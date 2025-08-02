using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OfflineTicketingSystem.Domain.Common;

public abstract class BaseEntity
{
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
