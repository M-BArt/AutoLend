using AutoLend.Domain.DataModels.Client;
using AutoLend.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AutoLend.Infrastructure.Repositories {
    internal class CarRepository : ICarRepository {

        private readonly string _connectionString;

        public CarRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }
        public Task CreateAsync( Car car ) {
            throw new NotImplementedException();
        }

        public Task DeleteAsync( Guid carId ) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car?>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<Car?> GetByIdAsync( Guid carId ) {
            throw new NotImplementedException();
        }

        public Task UpdateAsync( Car car ) {
            throw new NotImplementedException();
        }
    }
}
