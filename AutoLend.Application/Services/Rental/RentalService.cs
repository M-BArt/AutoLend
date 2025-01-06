using AutoLend.Core.ApiModels.Rental;
using AutoLend.Core.Esceptions;
using AutoLend.Data.CoreModels.Rental;
using AutoLend.Data.Repositories.Car;
using AutoLend.Data.Repositories.Rental;

namespace AutoLend.Core.Services.Rental
{
    internal class RentalService : IRentalService
    {

        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;

        public RentalService( IRentalRepository rentalRepository, ICarRepository carRepository)
        {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
        }
        public async Task CreateRental( RentalCreateRequest rental )
        {

            if ((rental.ReturnDate - rental.RentalDate).Days > 7) throw new BusinessException("Rental period too long"); 
            
            var car = await _carRepository.GetByLicensePlateAsync(rental.LicensePlate) ?? throw new BusinessException("No found car with the given license plates");
            
            var TotalCost = ((rental.ReturnDate - rental.RentalDate).Days) * car.Cost;
            
            RentalCreateDTO rentalDto = new() {
                LicensePlate = rental.LicensePlate,
                LicenseNumber = rental.LicenseNumber,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
                TotalCost = TotalCost
            };

            await _rentalRepository.CreateAsync(rentalDto);
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

        public async Task UpdateRental(RentalUpdateRequest rental )
        {
            //RentalUpdateDTO rentalDto = new() {

            //};

            //await _rentalRepository.UpdateAsync(rentalDto);
        }
    }
}
