namespace AutoLend.Data.CoreModels.Car {
    public class CarCreateDTO {
        public required int ModelId { get; set; }
        public required int Year { get; set; }
        public required string LicensePlate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
