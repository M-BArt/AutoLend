using AutoLend.Data.CoreModels.Rental;
using AutoLend.Data.DataModels.Car;
using AutoLend.Data.Resources.Rental;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Transactions;

namespace AutoLend.Data.Repositories.Rental {
    internal class RentalRepository : IRentalRepository {

        private readonly string _connectionString;
        public RentalRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }
        public async Task<int> CreateAsync( RentalCreateDTO rental ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();

                var parameters = new {
                    rental.LicensePlate,
                    rental.LicenseNumber,
                    rental.RentalDate,
                    rental.ReturnDate,
                    rental.TotalCost
                };

                
                return await connection.ExecuteAsync(Sql.Rental_Create, parameters);
            }
        }
        public async Task<IEnumerable<DataModels.Rental.Rental?>> GetAllAsync() {
            using (SqlConnection connection = new(_connectionString)) {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                await connection.OpenAsync();
                return await connection.QueryAsync<DataModels.Rental.Rental>(Sql.Rental_GetAll);
                }
            }
        }
        public async Task<DataModels.Rental.Rental?> GetByIdAsync( int rentalId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<DataModels.Rental.Rental>(Sql.Rental_GetById, new { rentalId });
            }
        }
        public async Task UpdateAsync( RentalUpdateDTO rental ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();

                var parameters = new {
                    rental.RentalId,
                    rental.StatusId,
                    rental.RentalDate,
                    rental.ReturnDate,
                    rental.TotalCost,
                };

                await connection.ExecuteAsync(Sql.Rental_Update, parameters);
            }
        }
        public async Task DeleteAsync( int rentalId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                    await connection.ExecuteAsync(Sql.Rental_Delete, new { rentalId });
                    transaction.Complete();
                }
            }
        }
        public async Task UpdateStatusAsync( int rentalId, int statusId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                await connection.ExecuteAsync(Sql.Rental_UpdateStatusAsync, new { rentalId, statusId });
            }
        }
        public async Task<IEnumerable<DataModels.Rental.Rental?>> GetItemsWithPastReturnDateAsync() {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryAsync<DataModels.Rental.Rental>(Sql.Rental_GetItemsWithPastReturnDateAsync);
            }
        }
    }
}
