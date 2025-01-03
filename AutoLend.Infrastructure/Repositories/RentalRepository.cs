using AutoLend.Domain.DataModels.Customer;
using AutoLend.Domain.DataModels.Rental;
using AutoLend.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AutoLend.Infrastructure.Repositories {
    internal class RentalRepository : IRentalRepository {

        private readonly string _connectionString;

        public RentalRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }

        public async Task CreateAsync( Rental rental ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Rental\\Rental_Create.sql"));
                await connection.ExecuteAsync(query, rental);
            }
        }
        public async Task<IEnumerable<Rental?>> GetAllAsync() {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Rental\\Rental_GetAll.sql"));
                return await connection.QueryAsync<Rental>(query);
            }
        }
        public async Task<Rental?> GetByIdAsync( int rentalId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Rental\\Rental_GetById.sql"));
                return await connection.QueryFirstOrDefaultAsync<Rental>(query, new { rentalId });
            }
        }
        public async Task UpdateAsync( Rental rental ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Rental\\Rental_Update.sql"));
                await connection.ExecuteAsync(query, new { rental });
            }
        }
        public async Task DeleteAsync( int rentalId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Rental\\Rental_Delete.sql"));
                await connection.ExecuteAsync(query, new { rentalId });
            }
        }
    }
}
