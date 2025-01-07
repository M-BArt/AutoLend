namespace AutoLend.Data.DataModels.Car {
    public class CarGetByLicensePlate {
        public required int Id { get; set; }
        public required string LicensePlate { get; set; }
        public required bool IsAvailable { get; set; }
        public required decimal Cost { get; set; }
    }
}
