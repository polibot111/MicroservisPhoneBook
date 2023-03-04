using MassTransitCommon.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitCommon.Extensions
{
    public static class QueueEnumExtension
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
