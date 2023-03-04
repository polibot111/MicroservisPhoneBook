using MassTransit;
using MassTransitService.Enums;
using MassTransitService.Extensions;
using MassTransitService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MassTransit.Monitoring.Performance.BuiltInCounters;

namespace MassTransitService
{
    public static class MassTransitRabbitMQService
    {
        readonly static string rabbitMQUri = "amqps://ptydxsmi:ehFw5rBP_SbQvayPgtrNWfuLKIj85UY6@sparrow.rmq.cloudamqp.com/ptydxsmi";
        readonly static string user = "ptydxsmi";
        readonly static string password = "ehFw5rBP_SbQvayPgtrNWfuLKIj85UY6";
        public static async Task Publisher<T>(QueueEnum[] queueList) where T : class, IConsumer, new()
        {
            string queue = QueueGenerator(queueList);
            
            var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(rabbitMQUri, configurator =>
                {
                    configurator.Username(user);
                    configurator.Password(password);
                });

            });

            var sendToUri = new Uri($"{rabbitMQUri}/{queue}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            await Task.Run(async () =>
            {

                T message = new();

                await endPoint.Send(message);

            });
        }

        public static async Task Consumer<T>(QueueEnum[] queueList, Func<bool> func) where T : class, IConsumer, new()
        {
            string queue = QueueGenerator(queueList);
            var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(rabbitMQUri, configurator =>
                {
                    configurator.Username(user);
                    configurator.Password(password);
                });

                factory.ReceiveEndpoint(queue, endpoint => endpoint.Consumer<T>());
            });
            await bus.StartAsync();
            var boolean = func;
            await bus.StopAsync();
        }

        public static string QueueGenerator(QueueEnum[] enums)
        {

                string queue = "";
                foreach (var item in enums)
                {
                    if (item != enums[^1])
                    {
                        queue += (item.DisplayName() + ".");
                    }

                    queue += item.DisplayName();

                }

                return  queue;   
        }

    }
}
