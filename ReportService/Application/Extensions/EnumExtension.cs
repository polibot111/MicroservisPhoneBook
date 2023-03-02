using ReportService.Application.Enums;
using System.ComponentModel;

namespace ReportService.Application.Extensions
{
    public static class EnumExtension
    {
        public static string DisplayName(this ReportStatuEnum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
              .GetType()
              .GetField(val.ToString())
              .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
