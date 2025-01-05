namespace AutoLend.Data.CoreModels.Car {
    public class CarSearchDTO {
        public string? ModelName { get; set; }
        public string? BrandName { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public string? LicensePlate { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
