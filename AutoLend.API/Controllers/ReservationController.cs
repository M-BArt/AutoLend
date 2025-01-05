using AutoLend.Core.Services.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers
{
    [Route("Reservation")]
    [ApiController]
    public partial class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationService _reservationService;
        public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }
    }
}
