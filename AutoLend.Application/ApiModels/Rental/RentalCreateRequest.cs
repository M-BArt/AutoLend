using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Rental {
    public class RentalCreateRequest {
        [RegularExpression(@"(^$|^[A-Z]{3}-\d{4}$)", ErrorMessage = "License plate must be in the format CCC-NNNN.")]
        public required string LicensePlate { get; set; }
        [RegularExpression(@"(^$|^[A-Z]{2}\d{8}$)", ErrorMessage = "License number must be in the format CCCNNNNNNNN.")]
        public required string LicenseNumber { get; set; }
        public required DateTime RentalDate { get; set; }
        public required DateTime ReturnDate { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext ) {
            if (ReturnDate > RentalDate) {

                yield return new ValidationResult(
                    $"rental date is greater than 'Return date'",
                    new[] { nameof(RentalDate) });
            }
            
        }
    }
}
