namespace AutoLend.Core.ApiModels.Reservation {
    public class ReservationUpdateRequest {
        public string? Description { get; set; }
        public DateTime? ReservationFrom { get; set; }
        public DateTime? ReservationTo { get; set; }
    }
}
