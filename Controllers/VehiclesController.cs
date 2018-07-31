using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zaap.Controllers.Resources;
using Zaap.Models;
using Zaap.Persistence;

namespace Zaap.Controllers
{

    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ZaapDbContext context;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitofwork;
        public VehiclesController(IMapper mapper, IVehicleRepository repository, IUnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork;
            this.repository = repository;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var v = await context.Vehicles.ToListAsync();
            return Ok(v);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound($"the id {id} cannot be found");
            }
            var vr = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(vr);

        }



        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleresource)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }
            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleresource);
            vehicle.LastUpdate = DateTime.Now;


            repository.Add(vehicle);
            await unitofwork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleresource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound($"the id {id} cannot be found");
            }
            mapper.Map<SaveVehicleResource, Vehicle>(vehicleresource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await unitofwork.CompleteAsync();
            vehicle = await repository.GetVehicle(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicleid = await repository.GetVehicle(id, includerelated: false);
            if (vehicleid == null)
            {
                return NotFound($"the id {id} does not exist");
            }
            repository.Remove(vehicleid);
            await unitofwork.CompleteAsync();
            return Ok(id);
        }
    }
}