using System.ComponentModel;

namespace ReportService.Application.Enums
{
    public enum ReportStatuEnum
    {
        [Description("Inceleniyor")]
        Inceleniyor = 0,
        [Description("Tamamlandı")]
        Tamamlandı = 1,
        [Description("Başarısız Oldu")]
        BaşarısızOldu = 2,
    }
}
