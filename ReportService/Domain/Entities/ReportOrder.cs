using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using ReportService.Domain.Abstract;

namespace ReportService.Domain.Entities
{
    public class ReportOrder:BaseEntity
    {
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public ReportContent Content{ get; set; }
        public string ReportContentId { get; set; }
    }
}
