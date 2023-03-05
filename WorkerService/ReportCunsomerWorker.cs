using MassTransit;
using MassTransitCommon;
using MassTransitCommon.Enums;
using MassTransitCommon.Model;
using Quartz;
using System.Collections.Generic;

namespace WorkerService
{
    public class ReportCunsomerWorker : IJob
    {

        public async Task Execute(IJobExecutionContext context)
        {

            List<QueueEnum> queueList = new List<QueueEnum>();
            queueList.Add(QueueEnum.ReportOrder);
            await Consumer(queueList);

        }

        public static async Task Consumer(List<QueueEnum> queueList)
        {
            string queue = QueueCreatorService.QueueGenerator(queueList);
            var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(MassTransitConnetcionValues.RabbitMQUri, configurator =>
                {
                    configurator.Username(MassTransitConnetcionValues.User);
                    configurator.Password(MassTransitConnetcionValues.Password);
                });

                factory.ReceiveEndpoint(queue, endpoint => endpoint.Consumer<ReportModelConsumer>());
            });
            await bus.StartAsync();
            Console.WriteLine("Sonuç");
            await bus.StopAsync();
        }
    }
}
