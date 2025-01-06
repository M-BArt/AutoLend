using AutoLend.Data.CoreModels.Car;
using AutoLend.Data.DataModels.Car;

namespace AutoLend.Data.Repositories.Car {
    public interface ICarRepository {
        Task<int> CreateAsync( CarCreateDTO car );
        Task<IEnumerable<DataModels.Car.Car?>> GetAllAsync();
        Task<DataModels.Car.Car?> GetByIdAsync( int carId );
        Task UpdateAsync( CarUpdateDTO car );
        Task DeleteAsync( int carId );
        Task<IEnumerable<CarSearch?>> SearchAsync( CarSearchDTO car );
        Task<CarGetByLicensePlate?> GetByLicensePlateAsync( string licensePlate );
        Task<bool> LicensePlateExistsAsync( string licenscePlate, int? excludePlate = null );
    }
}
