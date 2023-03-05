using MassTransit;
using MassTransitCommon.Model;
using RestSharp;
using System.Configuration;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Web;
using WorkerService.HttpFiles.Request;
using WorkerService.HttpFiles.Response;

namespace WorkerService
{
    public class ReportModelConsumer : IConsumer<IReportModel>
    {

        public async Task Consume(ConsumeContext<IReportModel> context)
        {
            Console.WriteLine("giriş");
            HttpClient client = new HttpClient();
            string phoneCreateReportServiceURL = "https://localhost:7161/api/Report";
            string reportCreateReportServiceURL = "https://localhost:7161/api/CreateReport/CreateReportContent";


            var builder = new UriBuilder(phoneCreateReportServiceURL);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["Latitude"] = context.Message.Latitude;
            query["Longitude"] = context.Message.Longitude;
            builder.Query = query.ToString();
            string url = builder.ToString();
            var result = await client.GetAsync(url);
            var phoneContent = await result.Content.ReadAsStringAsync();

            ReportCreaterServiceResponse? report = JsonSerializer.Deserialize<ReportCreaterServiceResponse>(phoneContent);

           // var clientGet = new RestClient(phoneCreateReportServiceURL);
           // var request = new RestRequest("search")
           //     .AddParameter("Latitude", context.Message.Latitude)
            //    .AddParameter("Longitude", context.Message.Longitude);
           // var report = await clientGet.GetAsync<ReportCreaterServiceResponse>(request);


            string reportCreateBodyJson = JsonSerializer.Serialize(new ReportCreateReportServiceRequest
            {
                CommunicationInfoCount = report.CommunicationInfoCount,
                Longitude = report.Longitude,
                Latitude = report.Latitude,
                PersonCount = report.PersonCount,
                ReportOrderId = Guid.Parse(context.Message.ReportOrderId)
            });


            var response = await client.PostAsync(
                reportCreateReportServiceURL,
                new StringContent(reportCreateBodyJson, Encoding.UTF8, "application/json"));


        }
    }
}
