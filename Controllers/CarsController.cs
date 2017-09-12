using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RallyeTime.Models;
using RallyeTime.Persistence;
using RallyeTime.Resources;

namespace RallyeTime.Controllers
{
    [Route("api/car")]
    public class CarsController : Controller
    {
        private readonly IMapper mapper;
        private readonly RallyeDbContext context;
        public CarsController(IMapper mapper, RallyeDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CarResource carResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var car = mapper.Map<CarResource, Car>(carResource);

            context.Cars.Add(car);
            await context.SaveChangesAsync();

            return Ok(car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] CarResource carResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var car = await context.Cars.Include(crs => crs.CourseSections).SingleOrDefaultAsync(c => c.Id == id);
            if(car != null) {
                mapper.Map<CarResource, Car>(carResource, car);
            } else {
                return NotFound();
            }

            await context.SaveChangesAsync();

            return Ok(car);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await context.Cars.Include(crs => crs.CourseSections).SingleOrDefaultAsync(c => c.Id == id);
            if(car == null)
                return NotFound();

            context.Remove(car);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var car = await context.Cars.Include(crs => crs.CourseSections).SingleOrDefaultAsync(c => c.Id == id);
            if (car == null)
                return NotFound();

            var carResource = mapper.Map<Car, CarResource>(car);

            return Ok(carResource);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCars()
        {
            var cars = await context.Cars.Include(crs => crs.CourseSections).ToListAsync();
            if (cars.Count == 0)
                return NotFound();

            var carResources = new List<CarResource>();
            foreach(var car in cars)
            {
                carResources.Add(mapper.Map<Car, CarResource>(car));
            }
            
            return Ok(carResources);
        }
    }
}