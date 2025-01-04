namespace AutoLend.Data.Repositories.Reservation
{
    public interface IReservationRepository
    {
        Task CreateAsync(DataModels.Reservation.Reservation reservation);
        Task<IEnumerable<DataModels.Reservation.Reservation?>> GetAllAsync();
        Task<DataModels.Reservation.Reservation?> GetByIdAsync(int reservationId);
        Task UpdateAsync(DataModels.Reservation.Reservation reservation);
        Task DeleteAsync(int reservationId);
    }
}
