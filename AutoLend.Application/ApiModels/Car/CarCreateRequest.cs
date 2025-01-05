using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Car {
    public class CarCreateRequest {

        [Required(ErrorMessage = "Model name is required.")]
        public required string ModelName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Year value is required.")]
        public required int Year { get; set; }
        [Required(ErrorMessage = "License plate is required.")]
        public required string LicensePlate { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}
