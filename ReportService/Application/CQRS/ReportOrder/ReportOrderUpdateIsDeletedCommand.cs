using MongoDB.Bson;

namespace ReportService.Application.CQRS.ReportOrder
{
    public class ReportOrderUpdateIsDeletedCommand
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
