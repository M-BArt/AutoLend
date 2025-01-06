namespace AutoLend.Data.CoreModels.Reservation {
    public class ReservationUpdateDTO {
        public required int Id { get; set; }
        public string? Description { get; set; }
        public DateTime? ReservationFrom { get; set; }
        public DateTime? ReservationTo { get; set; }
    }
}
