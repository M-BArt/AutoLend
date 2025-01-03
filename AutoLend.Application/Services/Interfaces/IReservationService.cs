using AutoLend.Domain.DataModels.Reservation;

namespace AutoLend.Application.Services.Interfaces {
    public interface IReservationService {
        Task CreateReservation( Reservation reservation );
        Task DeleteReservation( int reservationId );
        Task UpdateReservation( Reservation reservation );
        Task<IEnumerable<Reservation?>> GetAllReservations();
        Task<Reservation?> GetReservationById( int reservationId );
    }
}
