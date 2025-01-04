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
        public async Task CreateReservation(Data.DataModels.Reservation.Reservation reservation)
        {
            await _reservationRepository.CreateAsync(reservation);
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

        public async Task UpdateReservation(Data.DataModels.Reservation.Reservation reservation)
        {
            await _reservationRepository.UpdateAsync(reservation);
        }
    }
}
