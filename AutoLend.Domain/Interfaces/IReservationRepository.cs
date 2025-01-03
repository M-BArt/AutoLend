using AutoLend.Domain.DataModels.Reservation;

namespace AutoLend.Domain.Interfaces {
    public interface IReservationRepository {
        Task CreateAsync( Reservation reservation );
        Task<IEnumerable<Reservation?>> GetAllAsync();
        Task<Reservation?> GetByIdAsync( int reservationId );
        Task UpdateAsync( Reservation reservation );
        Task DeleteAsync( int reservationId );
    }
}
