using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Car {
    public class CarSearchRequest {
        public string? text { get; set; }
        public List<int>? ModelIds { get; set; }
        public int? BrandId { get; set; }
        public DateTime? YearFrom { get; set; }
        public DateTime? YearTo { get; set; }
        public bool? IsAvailable { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext ) {
            if (YearFrom != null && YearTo != null) {
                if (YearFrom > YearTo) {

                    yield return new ValidationResult(
                        $"YeraFrom jest większe niż YearTo",
                        new[] { nameof(YearFrom) });
                }
            }
        }
    }
}
