using AutoLend.Data.CoreModels.Car;
using AutoLend.Data.DataModels.Car;

namespace AutoLend.Data.Repositories.Car {
    public interface ICarRepository
    {
        Task CreateAsync( CarCreateDTO car );
        Task<IEnumerable<DataModels.Car.Car?>> GetAllAsync();
        Task<DataModels.Car.Car?> GetByIdAsync(int carId);
        Task UpdateAsync( CarUpdateDTO car );
        Task DeleteAsync(int carId);

        Task<IEnumerable<CarSearch?>> SearchAsync( CarSearchDTO car );
    }
}
