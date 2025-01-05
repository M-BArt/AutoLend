using AutoLend.Data.Resources.Rental;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AutoLend.Data.Repositories.Rental {
    internal class RentalRepository : IRentalRepository {

        private readonly string _connectionString;

        public RentalRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }

        public async Task CreateAsync( DataModels.Rental.Rental rental ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                await connection.ExecuteAsync(Sql.Rental_Create, rental);
            }
        }
        public async Task<IEnumerable<DataModels.Rental.Rental?>> GetAllAsync() {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryAsync<DataModels.Rental.Rental>(Sql.Rental_GetAll);
            }
        }
        public async Task<DataModels.Rental.Rental?> GetByIdAsync( int rentalId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<DataModels.Rental.Rental>(Sql.Rental_GetById, new { rentalId });
            }
        }
        public async Task UpdateAsync( DataModels.Rental.Rental rental ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                await connection.ExecuteAsync(Sql.Rental_Update, new { rental });
            }
        }
        public async Task DeleteAsync( int rentalId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                await connection.ExecuteAsync(Sql.Rental_Delete, new { rentalId });
            }
        }
    }
}
