namespace AutoLend.Data.DataModels.Reservation {
    public class Reservation {
        public required string Id { get; set; }
        public required DateTime CreateDate { get; set; }
        public required DateTime ModifyDate { get; set; }
        public required DateTime ReservationFrom { get; set; }
        public required DateTime ReservationTo { get; set; }
        public required string Description { get; set; }
        public required string StatusName { get; set; }
        public required string BrandName { get; set; }
        public required string ModelName { get; set; }
        public required string LicensePlate { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}

