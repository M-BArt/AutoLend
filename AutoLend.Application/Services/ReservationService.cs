using AutoLend.Application.Services.Interfaces;
using AutoLend.Domain.DataModels.Reservation;
using AutoLend.Domain.Interfaces;

namespace AutoLend.Application.Services {
    internal class ReservationService : IReservationService {
        
        private readonly IReservationRepository _reservationRepository;
        public ReservationService( IReservationRepository reservationRepository ) {
            _reservationRepository = reservationRepository;
        }
        public async Task CreateReservation( Reservation reservation ) {
            await _reservationRepository.CreateAsync(reservation);
        }

        public async Task DeleteReservation( int reservationId ) {
            await _reservationRepository.DeleteAsync(reservationId);
        }

        public async Task<IEnumerable<Reservation?>> GetAllReservations() {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation?> GetReservationById( int reservationId ) {
            return await _reservationRepository.GetByIdAsync(reservationId);
        }

        public async Task UpdateReservation( Reservation reservation ) {
            await _reservationRepository.UpdateAsync( reservation );
        }
    }
}
