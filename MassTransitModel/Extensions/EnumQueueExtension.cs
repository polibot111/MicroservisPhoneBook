using MassTransitService.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitService.Extensions
{
    public static class EnumQueueExtension
    {
        public static string DisplayName(this QueueEnum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
              .GetType()
              .GetField(val.ToString())
              .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
