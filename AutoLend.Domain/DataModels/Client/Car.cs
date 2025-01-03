namespace AutoLend.Domain.DataModels.Car {
    public class Car {
        public required int CarId {  get; set; }
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required string Year { get; set; }
        public required string LicensePlate { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
    }
}
