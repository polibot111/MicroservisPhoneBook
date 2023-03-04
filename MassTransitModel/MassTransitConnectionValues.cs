using MassTransit;
using MassTransitCommon.Enums;
using MassTransitCommon.Extensions;
using MassTransitCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MassTransit.Monitoring.Performance.BuiltInCounters;

namespace MassTransitCommon
{
    public const class MassTransitConnectionValues
    {
        public const string RabbitMQUri = "amqps://ptydxsmi:ehFw5rBP_SbQvayPgtrNWfuLKIj85UY6@sparrow.rmq.cloudamqp.com/ptydxsmi";
        public const string User = "ptydxsmi";
        public const string Password = "ehFw5rBP_SbQvayPgtrNWfuLKIj85UY6";

    }
}
