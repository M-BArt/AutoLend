using AutoLend.Data.Repositories.Car;
using AutoLend.Data.Repositories.Car.Car;
using AutoLend.Data.Repositories.Customer;
using AutoLend.Data.Repositories.Model;
using AutoLend.Data.Repositories.Rental;
using AutoLend.Data.Repositories.Reservation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AutoLend.Data {
    public static class DependencyIncjection {
        public static IServiceCollection AddDataServices( this IServiceCollection services, IConfiguration configuration ) {
            Configuration.SetConfiguration(configuration);

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            //services.AddScoped<IStatusRepository, StatusRepository>();

            return services;
        }
    }
}
