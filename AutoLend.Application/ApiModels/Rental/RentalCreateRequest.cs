using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Core.ApiModels.Rental {
    public class RentalCreateRequest {
        public required string LicensePlate { get; set; }
        public required string LicenseNumber { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
