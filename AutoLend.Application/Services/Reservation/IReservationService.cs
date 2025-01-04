namespace AutoLend.Core.Services.Reservation
{
    public interface IReservationService
    {
        Task CreateReservation(Data.DataModels.Reservation.Reservation reservation);
        Task DeleteReservation(int reservationId);
        Task UpdateReservation(Data.DataModels.Reservation.Reservation reservation);
        Task<IEnumerable<Data.DataModels.Reservation.Reservation?>> GetAllReservations();
        Task<Data.DataModels.Reservation.Reservation?> GetReservationById(int reservationId);
    }
}
