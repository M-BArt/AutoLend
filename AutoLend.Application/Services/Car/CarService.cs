using AutoLend.Core.ApiModels.Car;
using AutoLend.Data.CoreModels.Car;
using AutoLend.Data.DataModels.Car;
using AutoLend.Data.Repositories.Car;

namespace AutoLend.Core.Services.Car {
    internal class CarService : ICarService {

        private readonly ICarRepository _carRepository;

        public CarService( ICarRepository carRepository ) {
            _carRepository = carRepository;
        }

        public async Task CreateCar( CarCreateRequest car ) {
            CarCreateDTO CarDto = new() {
                ModelName = car.ModelName,
                Year = car.Year,
                LicensePlate = car.LicensePlate,
                IsAvailable = car.IsAvailable,
            };

            await _carRepository.CreateAsync(CarDto);
        }

        public async Task DeleteCar( int carId ) {
            await _carRepository.DeleteAsync(carId);
        }

        public async Task<IEnumerable<Data.DataModels.Car.Car?>> GetAllCars() {
            return await _carRepository.GetAllAsync();
        }

        public async Task<Data.DataModels.Car.Car?> GetCarById( int carId ) {
            return await _carRepository.GetByIdAsync(carId);
        }

        public async Task<IEnumerable<CarSearch?>> Search( CarSearchRequest car ) {

            CarSearchDTO CarDto = new() {
                ModelName = car.ModelName,
                BrandName = car.BrandName,
                YearFrom = car.YearFrom,
                YearTo = car.YearTo,
                LicensePlate = car.LicensePlate,
                IsAvailable = car.IsAvailable,
            };

            return await _carRepository.SearchAsync(CarDto);
        }

        public async Task UpdateCar( int carId, CarUpdateRequest car ) {
            CarUpdateDTO CarDto = new() {
                Id = carId,
                ModelName = car.ModelName,
                Year = car.Year,
                LicensePlate = car.LicensePlate,
                IsAvailable = car.IsAvailable,
            };

            await _carRepository.UpdateAsync(CarDto);
        }
    }
}
