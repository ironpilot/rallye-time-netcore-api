using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            var car = mapper.Map<CarResource, Car>(carResource);

            context.Cars.Add(car);
            await context.SaveChangesAsync();

            return Ok(car);
        }
    }
}