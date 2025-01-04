using AutoLend.Core.Services.Car;
using AutoLend.Core.Services.Customer;
using AutoLend.Core.Services.Rental;
using AutoLend.Core.Services.Reservation;
using Microsoft.Extensions.DependencyInjection;

namespace AutoLend.Core
{
    public static class DependencyIncjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IRentalService, RentalService>();
            services.AddScoped<IReservationService, ReservationService>();

            return services;
        }
    }
}
