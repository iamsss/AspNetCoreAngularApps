using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Controllers.Resource;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly VegaDbContext context;

        private readonly IMapper mapper;
        public VehiclesController(IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);

            vehicle.LastUpdate = DateTime.Now;
    
            context.Vehicles.Add(vehicle);
            
            await context.SaveChangesAsync();
    
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
    
            return Ok(result);
        }
    }
}