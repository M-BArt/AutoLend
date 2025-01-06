using AutoLend.Data.CoreModels.Rental;

namespace AutoLend.Data.Repositories.Rental {
    public interface IRentalRepository {
        Task<int> CreateAsync( RentalCreateDTO rental );
        Task<IEnumerable<DataModels.Rental.Rental?>> GetAllAsync();
        Task<DataModels.Rental.Rental?> GetByIdAsync( int rentalId );
        Task UpdateAsync( RentalUpdateDTO rental );
        Task DeleteAsync( int rentalId );
        Task UpdateStatusAsync( int rentalId, int statusId );
        Task<IEnumerable<DataModels.Rental.Rental?>> GetItemsWithPastReturnDateAsync();
    }
}
