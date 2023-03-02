using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReportService.Domain.Abstract
{
    public abstract class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
