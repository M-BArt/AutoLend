using AutoLend.Data.CoreModels.Reservation;

namespace AutoLend.Data.Repositories.Reservation {
    public interface IReservationRepository {
        Task CreateAsync( ReservationCreateDTO reservation );
        Task<IEnumerable<DataModels.Reservation.Reservation?>> GetAllAsync();
        Task<DataModels.Reservation.Reservation?> GetByIdAsync( int reservationId );
        Task UpdateAsync( ReservationUpdateDTO reservation );
        Task DeleteAsync( int reservationId );
    }
}
