using MassTransit;
using MassTransit.Configuration;
using Microsoft.Extensions.Options;
using ReportService;
using ReportService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<ReportServiceDbSettings>(
        builder.Configuration.GetSection("ReportServiceDatabase"));

builder.Services.AddScoped<IReportServiceDbSettings>(
    sp =>
    {
        return sp.GetRequiredService<IOptions<ReportServiceDbSettings>>().Value;
    });

builder.Services.AddReportServices();

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
