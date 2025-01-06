using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Reservation {
    public class ReservationUpdateRequest {
        public string? Description { get; set; }
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
