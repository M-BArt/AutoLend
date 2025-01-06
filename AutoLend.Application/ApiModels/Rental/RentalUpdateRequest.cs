using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Rental {
    public class RentalUpdateRequest {
        public int? StatusId {  get; set; } 
        public DateTime? RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext ) {
            if (ReturnDate > RentalDate) {

                yield return new ValidationResult(
                    $"'Rental date' is greater than 'Return date'",
                    new[] { nameof(RentalDate) });
            }

        }
    }
}
