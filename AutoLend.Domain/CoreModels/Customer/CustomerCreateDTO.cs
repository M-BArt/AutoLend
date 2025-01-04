using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Data.CoreModels.Customer {
    public class CustomerCreateDTO {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string LicenseNumber { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
