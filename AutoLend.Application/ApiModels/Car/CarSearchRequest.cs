using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Car {
    public class CarSearchRequest {
        public string? text { get; set; }
        public List<int>? ModelIds { get; set; }
        public int? BrandId { get; set; }
        public DateTime? YearFrom { get; set; }
        public DateTime? YearTo { get; set; }
        public bool? IsAvailable { get; set; }

        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public int? OrderDir { get; set; }



        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext ) {
            if (YearFrom != null && YearTo != null) {
                if (YearFrom > YearTo) {

                    yield return new ValidationResult(
                        $"'Year from is greater than 'Year to'",
                        new[] { nameof(YearFrom) });
                }
            }
        }
    }
}
