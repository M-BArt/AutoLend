using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Car {
    public class CarCreateRequest {

        [Required(ErrorMessage = "Model name is required.")]
        public required string ModelName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Year value is required.")]
        public required int Year { get; set; }
        [Required(ErrorMessage = "License plate is required.")]
        [RegularExpression(@"(^$|^[A-Z]{3}-\d{4}$)", ErrorMessage = "License plate must be in the format CCC-NNNN.")]
        public required string LicensePlate { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        [Range(10, double.MaxValue, ErrorMessage = "Cost must be a positive value.")]
        public required decimal Cost { get; set; }
    }
}
