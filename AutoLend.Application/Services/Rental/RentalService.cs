using AutoLend.Core.ApiModels.Rental;
using AutoLend.Core.Esceptions;
using AutoLend.Data.CoreModels.Rental;
using AutoLend.Data.DataModels.Car;
using AutoLend.Data.Repositories.Car;
using AutoLend.Data.Repositories.Customer;
using AutoLend.Data.Repositories.Rental;

namespace AutoLend.Core.Services.Rental {
    internal class RentalService : IRentalService {

        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;

        public RentalService( IRentalRepository rentalRepository, ICarRepository carRepository, ICustomerRepository customerRepository ) {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
            _customerRepository = customerRepository;
        }
        public async Task CreateRental( RentalCreateRequest rental ) {

            if ((rental.ReturnDate - rental.RentalDate).Days > 14)
                throw new BusinessException("Rental period too long");

            var customer = await _customerRepository.GetByLicenseNumber(rental.LicenseNumber) ?? throw new BusinessException("Customer not found");

            if (customer.HasActiveRental)
                throw new BusinessException("Customer already has car on rental.");

            var car = await _carRepository.GetByLicensePlateAsync(rental.LicensePlate) ?? throw new BusinessException("No found car with the given license plates");

            if (!car.IsAvailable)
                throw new BusinessException("Car is not available.");
                  
            
            var TotalCost = (rental.ReturnDate - rental.RentalDate).Days * car.Cost;

            RentalCreateDTO rentalDto = new() {
                LicensePlate = rental.LicensePlate,
                LicenseNumber = rental.LicenseNumber,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
                TotalCost = TotalCost
            };

            await _rentalRepository.CreateAsync(rentalDto);
        }
        public async Task DeleteRental( int rentalId ) {
           
            await _rentalRepository.DeleteAsync(rentalId);
        }
        public async Task<Data.DataModels.Rental.Rental?> GetRentalById( int rentalId ) {
            return await _rentalRepository.GetByIdAsync(rentalId);
        }
        public async Task<IEnumerable<Data.DataModels.Rental.Rental?>> GetAllRentals() {
            return await _rentalRepository.GetAllAsync();
        }
        public async Task UpdateRental( int rentalId, RentalUpdateRequest rental ) {

            var oldRental = await _rentalRepository.GetByIdAsync(rentalId) ?? throw new BusinessException("Rental not found.");
            
            var car = await _carRepository.GetByIdAsync(oldRental.CarId) ?? throw new BusinessException("Car not found.");

                var rentalDate = rental.RentalDate ?? oldRental.RentalDate.Date;
                var returnDate = rental.ReturnDate ?? oldRental.ReturnDate.Date;

                var TotalCost = (returnDate - rentalDate).Days * car.Cost;

            if ((returnDate - rentalDate).Days > 14)
                throw new BusinessException("Rental period too long");

            RentalUpdateDTO rentalDto = new() {
                RentalId = rentalId,
                StatusId = rental.StatusId,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
                TotalCost = TotalCost,
            };

            await _rentalRepository.UpdateAsync(rentalDto); 
        }
    }
}
