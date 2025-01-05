using System.ComponentModel.DataAnnotations;

namespace AutoLend.Core.ApiModels.Reservation {
    public class ReservationSearchRequest {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string? Email { get; set; }
        public string? LicensePlate { get; set; }
        public string? Status { get; set; }
        public DateTime? ReservationFrom { get; set; }
        public DateTime? ReservationTo { get; set; }
    }
}
