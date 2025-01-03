using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Domain.DataModels.Client {
    public class Car {
        public required string Make {  get; set; }
        public required string Model {  get; set; }
        public required string Year { get; set; }
        public string? Condition { get; set; }
        public bool Available { get; set; }

    }
}
