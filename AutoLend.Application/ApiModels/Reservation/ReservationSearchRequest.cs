using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Core.ApiModels.Reservation {
    public class ReservationSearchRequest {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email {  get; set; }
        public string? LicensePlate { get; set; }
        public string? Status { get; set; }
        public DateTime? ReservationFrom { get; set; }
        public DateTime? ReservationTo { get; set; }
    }
}
