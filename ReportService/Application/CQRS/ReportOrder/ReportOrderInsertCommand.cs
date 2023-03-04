using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ReportService.Domain.Entities;
using ReportService.Application.Enums;
using ReportService.Application.Extensions;

namespace ReportService.Application.CQRS.ReportOrder
{
    public class ReportOrderInsertCommand
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? UpdatedAt { get; set; } = null;
        public bool IsDeleted { get; set; } = false;
        public string Status { get; set; } = ReportStatuEnum.Inceleniyor.DisplayName();

    }
}
