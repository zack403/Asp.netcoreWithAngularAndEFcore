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
        public VehiclesController(IMapper mapper, ZaapDbContext context)
        {
            this.context = context;
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
            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound($"the id {id} cannot be found");
            }
            var vr = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(vr);

        }



        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleresource)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleresource);
            vehicle.LastUpdate = DateTime.Now;


            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleResource vehicleresource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound($"the id {id} cannot be found");
            }
            mapper.Map<VehicleResource, Vehicle>(vehicleresource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicleid = await context.Vehicles.FindAsync(id);
            if (vehicleid == null)
            {
                return NotFound($"the id {id} does not exist");
            }
            context.Remove(vehicleid);
            await context.SaveChangesAsync();
            return Ok(id);
        }
    }
}