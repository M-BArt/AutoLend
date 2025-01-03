using AutoLend.Domain.DataModels.Client;

namespace AutoLend.Domain.Interfaces {
    public interface ICarRepository {
        Task CreateAsync(Car car);
        Task<IEnumerable<Car?>> GetAllAsync();
        Task<Car?> GetByIdAsync( Guid carId );
        Task UpdateAsync( Car car );
        Task DeleteAsync( Guid carId );
    }
}
