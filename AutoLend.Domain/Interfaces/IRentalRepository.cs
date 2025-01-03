using AutoLend.Domain.DataModels.Rental;

namespace AutoLend.Domain.Interfaces {
    public interface IRentalRepository {
        Task CreateAsync( Rental rental );
        Task<IEnumerable<Rental?>> GetAllAsync();
        Task<Rental?> GetByIdAsync( int rentalId );
        Task UpdateAsync( Rental rental );
        Task DeleteAsync( int rentalId );
    }
}
