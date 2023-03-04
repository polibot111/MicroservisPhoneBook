using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ReportService.Application.Enums;
using ReportService.Domain.Entities;

namespace ReportService.Application.CQRS.ReportOrder
{
    public class ReportOrderUpdateCommand
    {

        public string Id { get; set; }
        public ReportStatuEnum Status { get; set; }
        public ReportService.Domain.Entities.ReportContent Content { get; set; }
        public string ReportContentId { get; set; }
    }
}
