using AutoLend.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    [Route("Rental")]
    [ApiController]
    public partial class RentalController : ControllerBase {
        private readonly ILogger<RentalController> _logger;
        private readonly IRentalService _rentalService;
        public RentalController( ILogger<RentalController> logger, IRentalService rentalService ) {
            _logger = logger;
            _rentalService = rentalService;
        }

    }
}
