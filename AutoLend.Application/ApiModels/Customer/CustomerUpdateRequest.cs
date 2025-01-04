using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Core.ApiModels.Customer {
    public class CustomerUpdateRequest {
        public  string? FirstName { get; set; }
        public  string? LastName { get; set; }
        public  string? LicenseNumber { get; set; }
        public  string? Phone { get; set; }
        public  string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
