using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RallyeTime.Models;
using RallyeTime.Persistence;
using RallyeTime.Resources;

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

        [HttpGet("race/{RaceId}")]
        public async Task<Race> GetRace(int RaceId)
        {
            return await context.Races.Where(r => r.Id == RaceId).FirstOrDefaultAsync();
        }
    }
}