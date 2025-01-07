using AutoLend.Data.DataModels.Reservation;
using Azure;
using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Customer {
    public class CustomerUpdateRequest : IValidatableObject {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [RegularExpression(@"(^$|^[A-Z]{2}\d{8}$)", ErrorMessage = "License number must be in the format CCNNNNNNNN.")]
        public string? LicenseNumber { get; set; }
        [Phone(ErrorMessage = "Invalid Phone number")]
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext ) {

            if (DateOfBirth > DateTime.Now) {

                yield return new ValidationResult(
                    $"Date of birth is greater than current date",
                    new[] { nameof(DateOfBirth) });
            }

        }
    }
}
