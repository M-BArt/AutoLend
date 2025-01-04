using AutoLend.Data.Resources.Reservation;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace AutoLend.Data.Repositories.Reservation {
    internal class ReservationRepository : IReservationRepository {

        private readonly string _connectionString;

        public ReservationRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }

        public async Task CreateAsync( DataModels.Reservation.Reservation reservation ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                await connection.ExecuteAsync(Sql.Reservation_Create, reservation);
            }
        }
        public async Task<IEnumerable<DataModels.Reservation.Reservation?>> GetAllAsync() {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryAsync<DataModels.Reservation.Reservation>(Sql.Reservation_GetAll);
            }
        }
        public async Task<DataModels.Reservation.Reservation?> GetByIdAsync( int reservationId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<DataModels.Reservation.Reservation>(Sql.Reservation_GetById, new { reservationId });
            }
        }
        public async Task UpdateAsync( DataModels.Reservation.Reservation reservation ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                await connection.ExecuteAsync(Sql.Reservation_Update, new { reservation });
            }
        }
        public async Task DeleteAsync( int reservationId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                await connection.ExecuteAsync(Sql.Reservation_Delete, new { reservationId });
            }
        }
    }
}
