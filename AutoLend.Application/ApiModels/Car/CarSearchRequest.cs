using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Core.ApiModels.Car {
    public class CarSearchRequest {
        public string? ModelName { get; set; }
        public string? BrandName { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public string? LicensePlate { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
