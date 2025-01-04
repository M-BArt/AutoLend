namespace AutoLend.Data.Repositories.Rental
{
    public interface IRentalRepository
    {
        Task CreateAsync(DataModels.Rental.Rental rental);
        Task<IEnumerable<DataModels.Rental.Rental?>> GetAllAsync();
        Task<DataModels.Rental.Rental?> GetByIdAsync(int rentalId);
        Task UpdateAsync(DataModels.Rental.Rental rental);
        Task DeleteAsync(int rentalId);
    }
}
