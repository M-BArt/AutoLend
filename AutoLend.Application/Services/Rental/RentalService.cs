using AutoLend.Data.Repositories.Rental;

namespace AutoLend.Core.Services.Rental
{
    internal class RentalService : IRentalService
    {

        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public async Task CreateRental(Data.DataModels.Rental.Rental rental)
        {
            await _rentalRepository.CreateAsync(rental);
        }

        public async Task DeleteRental(int rentalId)
        {
            await _rentalRepository.DeleteAsync(rentalId);
        }

        public async Task<Data.DataModels.Rental.Rental?> GetRentalById(int rentalId)
        {
            return await _rentalRepository.GetByIdAsync(rentalId);
        }

        public async Task<IEnumerable<Data.DataModels.Rental.Rental?>> GetAllRentals()
        {
            return await _rentalRepository.GetAllAsync();
        }

        public async Task UpdateRental(Data.DataModels.Rental.Rental rental)
        {
            await _rentalRepository.UpdateAsync(rental);
        }
    }
}
