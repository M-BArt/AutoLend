using AutoLend.Data.CoreModels.Car;
using AutoLend.Data.DataModels.Car;
using AutoLend.Data.Resources.Car;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace AutoLend.Data.Repositories.Car.Car {
    internal class CarRepository : ICarRepository {

        private readonly string _connectionString;

        public CarRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }

        public async Task CreateAsync( CarCreateDTO car ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();

                var parameters = new {
                    car.ModelName,
                    car.Year,
                    car.LicensePlate,
                    car.IsAvailable
                };

                await connection.ExecuteAsync(Sql.Car_Create, parameters);
            }
        }
        public async Task<IEnumerable<DataModels.Car.Car?>> GetAllAsync() {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryAsync<DataModels.Car.Car>(Sql.Car_GetAll);
            }
        }
        public async Task<DataModels.Car.Car?> GetByIdAsync( int carId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<DataModels.Car.Car>(Sql.Car_GetById, new { carId });
            }
        }
        public async Task UpdateAsync( CarUpdateDTO car ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();

                var parameters = new {
                    car.Id,
                    car.ModelName,
                    car.Year,
                    car.LicensePlate,
                    car.IsAvailable
                };

                await connection.ExecuteAsync(Sql.Car_Update, parameters);
            }
        }
        public async Task DeleteAsync( int carId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                await connection.ExecuteAsync(Sql.Car_Delete, new { carId });
            }
        }

        public async Task<IEnumerable<CarSearch?>> SearchAsync( CarSearchDTO car ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();

                var parameters = new {
                    car.text,
                    car.ModelIdsJSON,
                    car.BrandId,
                    car.YearFrom,
                    car.YearTo,
                    car.IsAvailable,
                };

                return await connection.QueryAsync<CarSearch>(Sql.Car_Search, parameters);
            }
        }

        public async Task<CarGetByLicensePlate?> GetByLicensePlateAsync(string LicensePlate ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<CarGetByLicensePlate>(Sql.Car_GetByLicensePlate, new {LicensePlate});
            }
        }
    }
}
