using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Reservation {
    public class ReservationSearchRequest {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string? Email { get; set; }
        [RegularExpression(@"(^$|^[A-Z]{3}-\d{4}$)", ErrorMessage = "License plate must be in the format CCC-NNNN.")]
        public string? LicensePlate { get; set; }
        public string? Status { get; set; }
        public DateTime? ReservationFrom { get; set; }
        public DateTime? ReservationTo { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext ) {
            if (ReservationFrom > ReservationTo) {

                yield return new ValidationResult(
                    $"'Reservation from' is greater than 'Reservation to'",
                    new[] { nameof(ReservationFrom) });
            }

        }
    }
}
