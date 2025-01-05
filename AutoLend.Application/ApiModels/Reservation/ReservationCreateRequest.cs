using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Reservation {
    public class ReservationCreateRequest {
        public required DateTime ReservationFrom { get; set; }
        public required DateTime ReservationTo { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "License plate  is required.")]
        public required string LicensePlate { get; set; }

    }
}
