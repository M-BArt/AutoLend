namespace AutoLend.Data.CoreModels.Rental {
    public class RentalCreateDTO {
        public required string LicensePlate { get; set; }
        public required string LicenseNumber { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}
