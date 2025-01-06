using AutoLend.Data.CoreModels.Reservation;
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
        public async Task CreateAsync( ReservationCreateDTO reservation ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();

                var parameters = new {
                    reservation.ReservationFrom,
                    reservation.ReservationTo,
                    reservation.Description,
                    reservation.FirstName,
                    reservation.LastName,
                    reservation.Email,
                    reservation.LicensePlate,
                };

                await connection.ExecuteAsync(Sql.Reservation_Create, parameters);
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
        public async Task UpdateAsync( ReservationUpdateDTO reservation ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();

                var parameters = new {
                    reservation.Id,
                    reservation.ReservationFrom,
                    reservation.ReservationTo,
                    reservation.Description,
                };

                await connection.ExecuteAsync(Sql.Reservation_Update, parameters);
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
