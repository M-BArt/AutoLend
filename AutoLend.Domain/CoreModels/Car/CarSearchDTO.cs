using System.ComponentModel.DataAnnotations;

namespace AutoLend.Data.CoreModels.Car {
    public class CarSearchDTO {
        public string? text { get; set; }
        public string? ModelIdsJSON { get; set; }
        public int? BrandId { get; set; }
        public DateTime? YearFrom { get; set; }
        public DateTime? YearTo { get; set; }
        public bool? IsAvailable { get; set; }
    }


    public class ModelIdItem {
        public int ModelId { get; set; }
    };
}
