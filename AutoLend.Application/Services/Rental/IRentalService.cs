using AutoLend.Core.ApiModels.Rental;
using AutoLend.Data.CoreModels.Rental;

namespace AutoLend.Core.Services.Rental
{
    public interface IRentalService
    {
        Task CreateRental( RentalCreateRequest rental );
        Task DeleteRental(int rentalId);
        Task UpdateRental(RentalUpdateRequest rental);
        Task<IEnumerable<Data.DataModels.Rental.Rental?>> GetAllRentals();
        Task<Data.DataModels.Rental.Rental?> GetRentalById(int rentalId);
    }
}
