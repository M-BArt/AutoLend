namespace AutoLend.Data.CoreModels.Car {
    public class CarUpdateDTO {
        public required int Id { get; set; }
        public string? ModelName { get; set; }
        public int? Year { get; set; }
        public string? LicensePlate { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
