using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ReportService.Application.Enums;
using ReportService.Domain.Entities;

namespace ReportService.Application.CQRS.ReportOrder
{
    public class ReportOrderUpdateStatusCommand
    {
        public string Id { get; set; }
        public ReportStatuEnum Status { get; set; }
        

    }
}
