using Robot.Repository.Repositories;
using Robot.Repository.Repositories.Interface;
using Robot.Service.Mapper;
using Robot.Service.Services;
using Robot.Service.Services.Interface;

namespace Robot.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddScoped<ILogReppository, LogRepository>();
            services.AddScoped<ILogService, LogService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(MapperConfigProfile).Assembly);

            services.AddMemoryCache();

            services.AddHttpClient();

            return services;
        }
    }
}
