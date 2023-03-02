using PhoneBookService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PhoneBookService.Interface.Repositories;
using PhoneBookService.Repositories;
using PhoneBookService.Interface.Services;
using PhoneBookService.Services;

namespace PhoneBookService
{
    public static class ServiceRegistration
    {
        public static void AddPhoneBookServices(this IServiceCollection services) 
        {
            services.AddDbContext<PhoneBookServiceDbContext>(options => options.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=PhoneBookService;"));

            #region Repositories Section

            services.AddScoped<IPersonReadRepository, PersonReadRepository>();
            services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();
            services.AddScoped<ICommunicationInfoReadRepository, CommunicationInfoReadRepository>();
            services.AddScoped<ICommunicationInfoWriteRepository, CommunicationInfoWriteRepository>();

            #endregion

            #region Services Section

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICommunicationInfoService, CommunicationInfoService>();

            #endregion

        }
    }
}
