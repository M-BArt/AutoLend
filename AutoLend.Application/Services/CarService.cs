using AutoLend.Application.Services.Interfaces;
using AutoLend.Domain.DataModels.Car;
using AutoLend.Domain.Interfaces;

namespace AutoLend.Application.Services {
    internal class CarService : ICarService {
        
        private readonly ICarRepository _carRepository;

        public CarService( ICarRepository carRepository ) {
            _carRepository = carRepository;
        }
        public async Task CreateCar( Car car ) {
            await _carRepository.CreateAsync( car );
        }

        public async Task DeleteCar( int carId ) {
            await _carRepository.DeleteAsync(carId);
        }

        public async Task<IEnumerable<Car?>> GetAllCars() {
           return await _carRepository.GetAllAsync();
        }

        public async Task<Car?> GetCarById( int carId ) {
            return await _carRepository.GetByIdAsync(carId);
        }

        public async Task UpdateCar( Car car ) {
            await _carRepository.UpdateAsync(car);
        }
    }
}
