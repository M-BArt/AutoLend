namespace AutoLend.Core.ApiModels.Car {
    public class CarUpdateRequest {
        public string? ModelName { get; set; } = string.Empty;
        public int? Year { get; set; }
        public string? LicensePlate { get; set; } = string.Empty;
        public bool? IsAvailable { get; set; }
    }
}
