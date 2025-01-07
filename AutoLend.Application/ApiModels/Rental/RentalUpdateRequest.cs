using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Rental {
    public class RentalUpdateRequest : IValidatableObject {
        public int? StatusId {  get; set; } 
        public DateTime? RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext ) {
            
            if (RentalDate > ReturnDate) {
                yield return new ValidationResult(
                    $"'Rental date' is greater than 'Return date'",
                    new[] { nameof(RentalDate), nameof(ReturnDate) });
            }

        }
    }
}
