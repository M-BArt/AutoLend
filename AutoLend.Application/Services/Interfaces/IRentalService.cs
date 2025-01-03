using AutoLend.Domain.DataModels.Rental;

namespace AutoLend.Application.Services.Interfaces {
    public interface IRentalService {
        Task CreateRental( Rental rental );
        Task DeleteRental( int rentalId );
        Task UpdateRental( Rental rental );
        Task<IEnumerable<Rental?>> GetAllRentals();
        Task<Rental?> GetRentalById( int rentalId );
    }
}
