using AutoLend.Core.Esceptions;
using AutoLend.Data.DataModels.Rental;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers
{
    public partial class RentalController
    {
        /// <summary>
        /// Endpoint to update an existing rental.
        /// </summary>
        /// <param name="rental"></param>
        /// <param name="crentalId"></param>
        /// <returns></returns>
        [HttpPut("{rentalId}")]
        public async Task<IActionResult> Update([FromBody] Rental rental, [FromRoute] int crentalId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                //await _rentalService.UpdateRental(rental);
                return Ok("Rental updated");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);

                return ex switch {
                    BusinessException => BadRequest(ex.Message),
                    _ => StatusCode(500, "Internal Error Server")
                };
            }
        }
    }
}
