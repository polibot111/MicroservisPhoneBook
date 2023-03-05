using MassTransit;
using Quartz;
using WorkerService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionScopedJobFactory();

    // Create a "key" for the job
    var jobKey = new JobKey("CreateReport");

    // Register the job with the DI container
    q.AddJob<ReportCunsomerWorker>(opts => opts.WithIdentity(jobKey));

    // Create a trigger for the job
    q.AddTrigger(opts => opts
        .ForJob(jobKey) // link to the HelloWorldJob
        .WithIdentity("CreateReport-trigger") // give the trigger a unique name
        .WithCronSchedule("0 0/1 * 1/1 * ? *")); // run every 5 dakika

});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();
