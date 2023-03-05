using MassTransit;
using MassTransitCommon;
using MassTransitCommon.Enums;
using MassTransitCommon.Model;

namespace ReportService.MassTransit
{
    public class MassTransitPublisher
    {
        public static async Task Publisher(List<QueueEnum> queueList, ReportModel model) 
        {
            string queue = QueueCreatorService.QueueGenerator(queueList);

            var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(MassTransitConnetcionValues.RabbitMQUri, configurator =>
                {
                    configurator.Username(MassTransitConnetcionValues.User);
                    configurator.Password(MassTransitConnetcionValues.Password);
                });

            });

            var sendToUri = new Uri($"{MassTransitConnetcionValues.RabbitMQUri}/{queue}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            await Task.Run(async () =>
            {

                await endPoint.Send<IReportModel>(model);

            });
        }
    }
}
