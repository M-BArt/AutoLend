using AutoLend.Domain.DataModels.Client;
using AutoLend.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AutoLend.Infrastructure.Repositories {
    internal class RentalRepository : IRentalRepository {

        private readonly string _connectionString;

        public RentalRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }
        public Task CreateAsync( Rental car ) {
            throw new NotImplementedException();
        }

        public Task DeleteAsync( Guid carId ) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rental?>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<Rental?> GetByIdAsync( Guid carId ) {
            throw new NotImplementedException();
        }

        public Task UpdateAsync( Rental car ) {
            throw new NotImplementedException();
        }
    }
}
