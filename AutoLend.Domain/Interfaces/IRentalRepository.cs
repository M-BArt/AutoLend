using AutoLend.Domain.DataModels.Client;

namespace AutoLend.Domain.Interfaces {
    public interface IRentalRepository {
        Task CreateAsync( Rental car );
        Task<IEnumerable<Rental?>> GetAllAsync();
        Task<Rental?> GetByIdAsync( Guid carId );
        Task UpdateAsync( Rental car );
        Task DeleteAsync( Guid carId );
    }
}
