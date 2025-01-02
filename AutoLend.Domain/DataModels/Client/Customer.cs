
using System.ComponentModel.DataAnnotations;

namespace AutoLend.Domain.DataModels.Client {
    public class Customer {
        public Guid Id { get; set; }

        public required DateTime CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public required string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public required string Lastname { get; set; }

        [Required(ErrorMessage = "Email name is required")]
        public required string Email { get; set; } 

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string?  Gender { get; set; }

        public DateTime? DateOfBirth {  get; set; }
    }
}
