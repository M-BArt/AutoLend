namespace AutoLend.Domain.DataModels.Reservation {
    public class Reservation {
        public int ReservationId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
