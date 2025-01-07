using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Reservation  {
    public class ReservationCreateRequest : IValidatableObject {
        public required DateTime ReservationFrom { get; set; }
        public required DateTime ReservationTo { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "License plate  is required.")]
        [RegularExpression(@"(^$|^[A-Z]{3}-\d{4}$)", ErrorMessage = "License plate must be in the format CCC-NNNN.")]
        public required string LicensePlate { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext ) {
            if (ReservationFrom > ReservationTo) {

                yield return new ValidationResult(
                    $"'Reservation from' is greater than 'Reservation to'",
                    new[] { nameof(ReservationFrom) });
            }

        }
    }
}
