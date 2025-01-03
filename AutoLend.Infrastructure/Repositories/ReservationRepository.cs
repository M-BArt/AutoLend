using AutoLend.Domain.DataModels.Customer;
using AutoLend.Domain.DataModels.Reservation;
using AutoLend.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AutoLend.Infrastructure.Repositories {
    internal class ReservationRepository : IReservationRepository {

        private readonly string _connectionString;

        public ReservationRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }

        public async Task CreateAsync( Reservation reservation ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Reservation\\Reservation_Create.sql"));
                await connection.ExecuteAsync(query, reservation);
            }
        }
        public async Task<IEnumerable<Reservation?>> GetAllAsync() {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Reservation\\Reservation_GetAll.sql"));
                return await connection.QueryAsync<Reservation>(query);
            }
        }
        public async Task<Reservation?> GetByIdAsync( int reservationId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Reservation\\Reservation_GetById.sql"));
                return await connection.QueryFirstOrDefaultAsync<Reservation>(query, new { reservationId });
            }
        }
        public async Task UpdateAsync( Reservation reservation ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Reservation\\Reservation_Update.sql"));
                await connection.ExecuteAsync(query, new { reservation });
            }
        }
        public async Task DeleteAsync( int reservationId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Reservation\\Reservation_Delete.sql"));
                await connection.ExecuteAsync(query, new { reservationId });
            }
        }
    }
}
