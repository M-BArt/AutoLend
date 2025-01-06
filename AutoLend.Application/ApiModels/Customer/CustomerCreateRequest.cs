using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Customer {
    public class CustomerCreateRequest {

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "Email name is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "License number is required")]
        [RegularExpression(@"^[A-Z]{2}\d{8}$", ErrorMessage = "License number must be in the format CCNNNNNNNN.")]
        public required string LicenseNumber { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid Phone number")]
        public required string Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public required string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
