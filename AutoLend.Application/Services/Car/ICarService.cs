using AutoLend.Core.ApiModels.Car;
using AutoLend.Data.DataModels.Car;

namespace AutoLend.Core.Services.Car {
    public interface ICarService {
        Task CreateCar( CarCreateRequest car );
        Task DeleteCar( int carId );
        Task UpdateCar( int carId, CarUpdateRequest car );
        Task<IEnumerable<Data.DataModels.Car.Car?>> GetAllCars();
        Task<Data.DataModels.Car.Car?> GetCarById( int carId );
        Task<IEnumerable<CarSearch?>> Search( CarSearchRequest car );
    }
}
