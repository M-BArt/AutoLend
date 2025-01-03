using AutoLend.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CustomerController {
    [Route("Customer")]
    [ApiController]
    public partial class CustomerController : ControllerBase {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController( ILogger<CustomerController> logger, ICustomerService customerService ) {
            _logger = logger;
            _customerService = customerService;
        }
    }
}
