using AutoLend.Domain.DataModels.Client;
using AutoLend.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AutoLend.Infrastructure.Repositories {
    internal class ReservationRepository : IReservationRepository {

        private readonly string _connectionString;

        public ReservationRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }
        public Task CreateAsync( Reservation car ) {
            throw new NotImplementedException();
        }

        public Task DeleteAsync( Guid carId ) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation?>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<Reservation?> GetByIdAsync( Guid carId ) {
            throw new NotImplementedException();
        }

        public Task UpdateAsync( Reservation car ) {
            throw new NotImplementedException();
        }
    }
}
