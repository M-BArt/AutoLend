using AutoLend.Core.ApiModels.Car;
using AutoLend.Data.CoreModels.Car;
using AutoLend.Data.DataModels.Car;
using AutoLend.Data.Repositories.Car;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonConverter = Newtonsoft.Json.JsonConverter;

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

            var modelIds = car.ModelIds?.Select(x => new ModelIdItem() { 
                ModelId = x,
            }).ToList();

            var modelIdsJson = modelIds is null ? string.Empty: JsonConvert.SerializeObject(modelIds);

            CarSearchDTO CarDto = new() {
                ModelIdsJSON = modelIdsJson,
                BrandId = car.BrandId,
                YearFrom = car.YearFrom,
                YearTo = car.YearTo,
                IsAvailable = car.IsAvailable,
                Page = car.Page,
                PageSize = car.PageSize,
                OrderBy = car.OrderBy,
                OrderDir = car.OrderDir
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
