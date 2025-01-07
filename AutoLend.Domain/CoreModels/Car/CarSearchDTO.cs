namespace AutoLend.Data.CoreModels.Car {
    public class CarSearchDTO {
        public string? text { get; set; }
        public string? ModelIdsJSON { get; set; }
        public int? BrandId { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public bool? IsAvailable { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public int? OrderDir { get; set; }
    }

    public class ModelIdItem {
        public int ModelId { get; set; }
    };
}
