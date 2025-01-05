using AutoLend.Core.ApiModels.Reservation;
using AutoLend.Data.CoreModels.Reservation;
using AutoLend.Data.Repositories.Reservation;

namespace AutoLend.Core.Services.Reservation
{
    internal class ReservationService : IReservationService
    {

        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task CreateReservation( ReservationCreateRequest reservation )
        {
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

        public async Task DeleteReservation(int reservationId)
        {
            await _reservationRepository.DeleteAsync(reservationId);
        }

        public async Task<IEnumerable<Data.DataModels.Reservation.Reservation?>> GetAllReservations()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Data.DataModels.Reservation.Reservation?> GetReservationById(int reservationId)
        {
            return await _reservationRepository.GetByIdAsync(reservationId);
        }

        public async Task UpdateReservation(int reservationId, ReservationUpdateRequest reservation)
        {
            
            ReservationUpdateDTO ReservationDto = new() {
                Id = reservationId,
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                Description = reservation.Description,
            };

            await _reservationRepository.UpdateAsync(ReservationDto);
        }
    }
}
