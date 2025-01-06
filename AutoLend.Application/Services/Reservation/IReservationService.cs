using AutoLend.Core.ApiModels.Reservation;

namespace AutoLend.Core.Services.Reservation {
    public interface IReservationService {
        Task CreateReservation( ReservationCreateRequest reservation );
        Task DeleteReservation( int reservationId );
        Task UpdateReservation( int reservationId, ReservationUpdateRequest reservation );
        Task<IEnumerable<Data.DataModels.Reservation.Reservation?>> GetAllReservations();
        Task<Data.DataModels.Reservation.Reservation?> GetReservationById( int reservationId );
    }
}
