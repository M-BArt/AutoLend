namespace AutoLend.Data.DataModels.Car {
    public class Car {
        public required int Id { get; set; }
        public required string ModelName { get; set; }
        public required string BrandName { get; set; }
        public required int Year { get; set; }
        public required string LicensePlate { get; set; }
        public required bool IsAvailable { get; set; }
        public required decimal Cost { get; set; }
    }
}
