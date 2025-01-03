using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using AutoLend.Domain.Interfaces;
using AutoLend.Infrastructure.Repositories;


namespace AutoLend.Infrastructure {
    public static class DependencyIncjection {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration ) {
            Configuration.SetConfiguration(configuration);

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICustomerRepository, ClientRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            return services;
        }
    }
}
