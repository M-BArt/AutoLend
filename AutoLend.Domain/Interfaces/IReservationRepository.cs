using AutoLend.Domain.DataModels.Client;

namespace AutoLend.Domain.Interfaces {
    public interface IReservationRepository {
        Task CreateAsync( Reservation car );
        Task<IEnumerable<Reservation?>> GetAllAsync();
        Task<Reservation?> GetByIdAsync( Guid carId );
        Task UpdateAsync( Reservation car );
        Task DeleteAsync( Guid carId );
    }
}
