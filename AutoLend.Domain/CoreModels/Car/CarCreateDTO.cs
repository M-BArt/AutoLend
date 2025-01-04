namespace AutoLend.Data.CoreModels.Car {
    public class CarCreateDTO {
        public required string ModelName { get; set; }
        public required int Year { get; set; }
        public required string LicensePlate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
