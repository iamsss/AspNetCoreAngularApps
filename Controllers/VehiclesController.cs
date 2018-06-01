using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resource;
using vega.Models;
using vega.Core;
using vega.Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace vega.Controllers
{
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public VehiclesController(IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin,Manager")]
        [Authorize(Policy = "HaveEmail")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            // Model Validation For DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Businness Logic Validation
            // if(true) {
            //     ModelState.AddModelError("..","error");
            //     return BadRequest(ModelState);
            // }
            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);

            vehicle.LastUpdate = DateTime.Now;

            repository.Add(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await repository.GetVehicle(id);
            if (vehicle == null)
                return NotFound();

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}"),Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id, includeRelated: false);

            if (vehicle == null)
                return NotFound();

            repository.Remove(vehicle);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

    }
}