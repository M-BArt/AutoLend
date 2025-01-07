using AutoLend.Core.Esceptions;
using AutoLend.Data.Repositories.Rental;
using AutoLend.Data.Repositories.Reservation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutoLend.Core.Services.HostedService {
    internal class MonitorRentalDateService : BackgroundService {

        private readonly IServiceProvider _services;
        public MonitorRentalDateService( IServiceProvider services ) {
            _services = services;
        }

        protected override async Task ExecuteAsync( CancellationToken stoppingToken ) {

            using IServiceScope? scope = _services.CreateScope();

            IRentalRepository _rentalRepository = scope.ServiceProvider.GetService<IRentalRepository>() ?? throw new BusinessException("Rental Repository not found");
            IReservationRepository _reservationRepository = scope.ServiceProvider.GetService<IReservationRepository>() ?? throw new BusinessException("Rental Repository not found");
            ;

            while (!stoppingToken.IsCancellationRequested) {

                var items = await _rentalRepository.GetItemsWithPastReturnDateAsync();

                foreach (var item in items) {
                    await _rentalRepository.UpdateStatusAsync(item!.Id, 4);
                }

                await Task.Delay(1000 * 60 * 15, stoppingToken);
            }
        }
    }
}
