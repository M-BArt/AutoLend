using AutoLend.Application.Services;
using AutoLend.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AutoLend.Application {
    public static class DependencyIncjection {
        public static IServiceCollection AddApplicationServices( this IServiceCollection services ) {

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IRentalService, RentalService>();
            services.AddScoped<IReservationService, ReservationService>();

            return services;
        }
    }
}
