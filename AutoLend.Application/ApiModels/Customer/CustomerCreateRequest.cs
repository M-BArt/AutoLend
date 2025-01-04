using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Core.ApiModels.Customer {
    public class CustomerCreateRequest {

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "Email name is required")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "License number is required")]
        public required string LicenseNumber { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public required string Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public required string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
