using AutoLend.Domain.DataModels.Car;
using AutoLend.Domain.DataModels.Customer;
using AutoLend.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AutoLend.Infrastructure.Repositories {
    internal class CarRepository : ICarRepository {

        private readonly string _connectionString;

        public CarRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }

        public async Task CreateAsync( Car car ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Car\\Car_Create.sql"));
                await connection.ExecuteAsync(query, car);
            }
        }
        public async Task<IEnumerable<Car?>> GetAllAsync() {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Car\\Car_GetAll.sql"));
                return await connection.QueryAsync<Car>(query);
            }
        }
        public async Task<Car?> GetByIdAsync( int carId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Car\\Car_GetById.sql"));
                return await connection.QueryFirstOrDefaultAsync<Car>(query, new { carId });
            }
        }
        public async Task UpdateAsync( Car car ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Car\\Car_Update.sql"));
                await connection.ExecuteAsync(query, new { car });
            }
        }
        public async Task DeleteAsync( int carId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Car\\Car_Delete.sql"));
                await connection.ExecuteAsync(query, new { carId });
            }
        }
    }
}
