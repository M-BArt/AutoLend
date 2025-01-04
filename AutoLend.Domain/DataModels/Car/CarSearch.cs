namespace AutoLend.Data.DataModels.Car {
    public class CarSearch {
        public string? ModelName { get; set; }
        public string? BrandName { get; set; }
        public int? Year { get; set; }
        public string? LicensePlate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
