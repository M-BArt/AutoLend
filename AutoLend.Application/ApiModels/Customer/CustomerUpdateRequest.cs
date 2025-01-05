using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Customer {
    public class CustomerUpdateRequest {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? LicenseNumber { get; set; }
        [Phone(ErrorMessage = "Invalid Phone number")]
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
