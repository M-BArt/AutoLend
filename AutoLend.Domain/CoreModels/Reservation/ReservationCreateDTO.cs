namespace AutoLend.Data.CoreModels.Reservation {
    public class ReservationCreateDTO {
        public required DateTime ReservationFrom { get; set; }
        public required DateTime ReservationTo { get; set; }
        public string? Description { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string LicensePlate { get; set; }
    }
}
