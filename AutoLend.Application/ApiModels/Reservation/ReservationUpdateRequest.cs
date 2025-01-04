using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Core.ApiModels.Reservation {
    public class ReservationUpdateRequest {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Descriptions { get; set; }
    }
}
