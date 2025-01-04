namespace AutoLend.Core.Services.Rental
{
    public interface IRentalService
    {
        Task CreateRental(Data.DataModels.Rental.Rental rental);
        Task DeleteRental(int rentalId);
        Task UpdateRental(Data.DataModels.Rental.Rental rental);
        Task<IEnumerable<Data.DataModels.Rental.Rental?>> GetAllRentals();
        Task<Data.DataModels.Rental.Rental?> GetRentalById(int rentalId);
    }
}
