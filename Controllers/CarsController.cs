using System.Threading.Tasks;
using AutoMapper;
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
            }

            await context.SaveChangesAsync();

            return Ok(car);
        }
    }
}