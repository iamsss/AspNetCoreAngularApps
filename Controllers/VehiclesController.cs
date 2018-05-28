using Microsoft.AspNetCore.Mvc;
using vega.Models;

namespace vega.Controllers
{
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] Vehicle Vechile ) {
            return Ok(Vechile);
        }

        [HttpGet]
        public IActionResult GetVehicle(Vehicle Vechile ) {
            return Ok("Sucess");
        }
    }
}