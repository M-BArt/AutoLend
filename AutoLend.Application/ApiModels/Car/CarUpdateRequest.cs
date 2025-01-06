using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Car {
    public class CarUpdateRequest {
        public string? ModelName { get; set; } = string.Empty;
        public int? Year { get; set; }
        [RegularExpression(@"(^$|^[A-Z]{3}-\d{4}$)", ErrorMessage = "License plate must be in the format CCC-NNNN.")]
        public string? LicensePlate { get; set; } = string.Empty;
        public bool? IsAvailable { get; set; }
        public decimal? Cost { get; set; }
    }
}
