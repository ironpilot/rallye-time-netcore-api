using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RallyeTime.Models;
using RallyeTime.Persistence;
using RallyeTime.Resources.Car;
using RallyeTime.Resources.Race;

namespace RallyeTime.Controllers
{
    [Route("api/[controller]")]
    public class RacesController : Controller
    {
        private readonly RallyeDbContext context;
        private readonly IMapper mapper;
        public RacesController(RallyeDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<RaceResource>> GetRaces()
        {
            var races = await context.Races.Include(r => r.Checkpoints).ToListAsync();

            return mapper.Map<List<Race>, List<RaceResource>>(races);
        }

        [HttpGet("{RaceId}")]
        public async Task<Race> GetRace(int RaceId)
        {
            return await context.Races.Where(r => r.Id == RaceId).FirstOrDefaultAsync();
        }

        [HttpGet("{RaceId}/cars")]
        public async Task<IEnumerable<CarResource>> GetCarsInRace(int RaceId)
        {
            var cars = await context.Cars.Where(c => c.RaceId == RaceId).ToListAsync();
            
            return mapper.Map<List<Car>, List<CarResource>>(cars);
        }

        [HttpPost("verify/{RaceId}")]
        public async Task<IActionResult> VerifyAccessCode(int RaceId, [FromBody] AccessResource accessResource)
        {
            Race race = await context.Races.Where(r => r.Id == RaceId).FirstOrDefaultAsync();

            if(race?.AccessCode == accessResource.AccessCode)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}