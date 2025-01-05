using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLend.Data.CoreModels.Reservation {
    public class ReservationUpdateDTO {
        public required int Id { get; set; }
        public string? Description { get; set; }
        public DateTime? ReservationFrom { get; set; }
        public DateTime? ReservationTo { get; set; }
    }
}
