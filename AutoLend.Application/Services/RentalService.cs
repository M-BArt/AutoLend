using AutoLend.Application.Services.Interfaces;
using AutoLend.Domain.DataModels.Rental;
using AutoLend.Domain.Interfaces;

namespace AutoLend.Application.Services {
    internal class RentalService : IRentalService {

        private readonly IRentalRepository _rentalRepository;

        public RentalService( IRentalRepository rentalRepository ) {
            _rentalRepository = rentalRepository;
        }
        public async Task CreateRental( Rental rental ) {
            await _rentalRepository.CreateAsync( rental );
        }

        public async Task DeleteRental( int rentalId ) {
            await _rentalRepository.DeleteAsync(rentalId);
        }

        public async Task<Rental?> GetRentalById( int rentalId ) {
            return await _rentalRepository.GetByIdAsync(rentalId);
        }

        public async Task<IEnumerable<Rental?>> GetAllRentals() {
            return await _rentalRepository.GetAllAsync();
        }

        public async Task UpdateRental( Rental rental ) {
            await _rentalRepository.UpdateAsync(rental);
        }
    }
}
