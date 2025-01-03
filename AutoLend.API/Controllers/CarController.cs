using AutoLend.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CarController {
    [Route("Car")]
    [ApiController]
    public partial class CarController : ControllerBase {
        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carService;
        public CarController( ILogger<CarController> logger, ICarService carService ) {
            _logger = logger;
            _carService = carService;
        }
    }
}
