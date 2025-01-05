using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Data.DataModels.Car {
    public class CarGetByLicensePlate {
        public required int Id { get; set; }
        public required string LicensePlate {  get; set; }
        public required decimal Cost { get; set; }
    }
}
