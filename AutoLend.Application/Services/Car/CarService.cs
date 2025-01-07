using AutoLend.Core.ApiModels.Car;
using AutoLend.Core.Esceptions;
using AutoLend.Data.CoreModels.Car;
using AutoLend.Data.DataModels.Car;
using AutoLend.Data.Repositories.Car;
using AutoLend.Data.Repositories.Model;
using AutoLend.Data.Repositories.Rental;
using Newtonsoft.Json;
using System.Data;

namespace AutoLend.Core.Services.Car {
    internal class CarService : ICarService {

        private readonly ICarRepository _carRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IModelRepository _modelRepository;
        public CarService( ICarRepository carRepository, IModelRepository modelRepository, IRentalRepository rentalRepository ) {
            _carRepository = carRepository;
            _modelRepository = modelRepository;
            _rentalRepository = rentalRepository;
        }
        public async Task CreateCar( CarCreateRequest car ) {

            if (await _carRepository.LicensePlateExistsAsync(car.LicensePlate))
                throw new BusinessException("License plate already exist.");

            var ModelId = (await _modelRepository.GetByModelNameAsync(car.ModelName)) ?? throw new BusinessException("Model name not found");

            if (car.Year > DateTime.Now.Year)
                throw new BusinessException("Wrong year.");

            CarCreateDTO CarDto = new() {
                ModelId = ModelId.Id,
                Year = car.Year,
                LicensePlate = car.LicensePlate,
                IsAvailable = car.IsAvailable,
                Cost = car.Cost,
            };

            await _carRepository.CreateAsync(CarDto);
        }
        public async Task DeleteCar( int carId ) {

            if (await _carRepository.GetByIdAsync(carId) is null)
                throw new BusinessException("Car not found or is not active.");

            if ((await _rentalRepository.GetAllAsync()).Where(x => x != null && x.CarId == carId && x.StatusName == "Confirmed").Any())
                throw new BusinessException("Cannot remove car is active rental.");
                
            await _carRepository.DeleteAsync(carId);
        }
        public async Task<IEnumerable<Data.DataModels.Car.Car?>> GetAllCars() {
            return await _carRepository.GetAllAsync();
        }
        public async Task<Data.DataModels.Car.Car?> GetCarById( int carId ) {
            return await _carRepository.GetByIdAsync(carId) ?? throw new BusinessException("Car not found");
        }
        public async Task<IEnumerable<CarSearch?>> Search( CarSearchRequest car ) {

            var modelIds = car.ModelIds?.Select(x => new ModelIdItem() {
                ModelId = x,
            }).ToList();

            var modelIdsJson = modelIds is null ? null : JsonConvert.SerializeObject(modelIds);

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


            var carObject = await _carRepository.GetByIdAsync(carId);

            if (carObject is null)
                throw new BusinessException("Car not found.");

            if (!string.IsNullOrEmpty(car.LicensePlate))
                if (await _carRepository.LicensePlateExistsAsync(car.LicensePlate, carId))
                    throw new BusinessException("License plate already exist.");

            if (!string.IsNullOrEmpty(car.ModelName))
                if (await _modelRepository.GetByModelNameAsync(car.ModelName) is null)
                    throw new BusinessException("Model name not found.");

            if (car.Year.HasValue && car.Year > DateTime.Now.Year)
                if (car.Year > DateTime.Now.Year)
                    throw new BusinessException("Wrong year.");

            CarUpdateDTO CarDto = new() {
                Id = carId,
                ModelName = car.ModelName,
                Year = car.Year,
                LicensePlate = car.LicensePlate,
                IsAvailable = car.IsAvailable,
                Cost = car.Cost
            };

            await _carRepository.UpdateAsync(CarDto);
        }
    }
}
