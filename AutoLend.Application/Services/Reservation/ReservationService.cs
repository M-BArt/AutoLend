using AutoLend.Core.ApiModels.Reservation;
using AutoLend.Core.Esceptions;
using AutoLend.Data.CoreModels.Reservation;
using AutoLend.Data.Repositories.Car;
using AutoLend.Data.Repositories.Customer;
using AutoLend.Data.Repositories.Reservation;

namespace AutoLend.Core.Services.Reservation {
    internal class ReservationService : IReservationService {

        private readonly IReservationRepository _reservationRepository;
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;
        public ReservationService( IReservationRepository reservationRepository, ICarRepository carRepository, ICustomerRepository customerRepository ) {
            _reservationRepository = reservationRepository;
            _carRepository = carRepository;
            _customerRepository = customerRepository;
        }
        public async Task CreateReservation( ReservationCreateRequest reservation ) {

            if (!(await _carRepository.LicensePlateExistsAsync(reservation.LicensePlate)))
                throw new BusinessException("License plate not found");

            if (!(await _customerRepository.IsCustomerFieldUniqueAsync("Email", reservation.Email)))
                throw new BusinessException("Email not exists.");

            ReservationCreateDTO ReservationDto = new() {
                ReservationFrom = reservation.ReservationFrom,
                ReservationTo = reservation.ReservationTo,
                Description = reservation.Description,
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                Email = reservation.Email,
                LicensePlate = reservation.LicensePlate,
            };

            await _reservationRepository.CreateAsync(ReservationDto);
        }
        public async Task DeleteReservation( int reservationId ) {
            if (await _reservationRepository.GetByIdAsync(reservationId) is null)
                throw new BusinessException("Reservation not found or is not active.");

            await _reservationRepository.DeleteAsync(reservationId);
        }
        public async Task<IEnumerable<Data.DataModels.Reservation.Reservation?>> GetAllReservations() {
            return await _reservationRepository.GetAllAsync();
        }
        public async Task<Data.DataModels.Reservation.Reservation?> GetReservationById( int reservationId ) {
            return await _reservationRepository.GetByIdAsync(reservationId) ?? throw new BusinessException("Reservation not found.");
        }
        public async Task UpdateReservation( int reservationId, ReservationUpdateRequest reservation ) {

            if (_reservationRepository.GetByIdAsync(reservationId) is null)
                throw new BusinessException("Reservation not found.");

            ReservationUpdateDTO ReservationDto = new() {
                Id = reservationId,
                ReservationFrom = reservation.ReservationFrom,
                ReservationTo = reservation.ReservationTo,
                Description = reservation.Description,
            };

            await _reservationRepository.UpdateAsync(ReservationDto);
        }
    }
}
