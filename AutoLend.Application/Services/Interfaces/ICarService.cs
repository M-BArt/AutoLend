using AutoLend.Domain.DataModels.Car;

namespace AutoLend.Application.Services.Interfaces {
    public interface ICarService {
        Task CreateCar( Car car );
        Task DeleteCar( int carId );
        Task UpdateCar( Car car );
        Task<IEnumerable<Car?>> GetAllCars();
        Task<Car?> GetCarById( int carId );
    }
}
