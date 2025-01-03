using AutoLend.Domain.DataModels.Car;

namespace AutoLend.Domain.Interfaces {
    public interface ICarRepository {
        Task CreateAsync(Car car);
        Task<IEnumerable<Car?>> GetAllAsync();
        Task<Car?> GetByIdAsync( int carId );
        Task UpdateAsync( Car car );
        Task DeleteAsync( int carId );
    }
}
