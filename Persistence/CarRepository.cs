using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RallyeTime.Models;

namespace RallyeTime.Persistence
{
    public class CarRepository : ICarRepository
    {
        private readonly RallyeDbContext context;
        public CarRepository(RallyeDbContext context)
        {
            this.context = context;
        }
        public async Task<Car> GetCar(int id)
        {
            return await context
                .Cars
                .Include(crs => crs.CourseSections)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await context.Cars.Include(crs => crs.CourseSections).ToListAsync();
        }

        public void Add(Car car)
        {
            context.Cars.Add(car);
        }

        public void Remove(Car car)
        {
            context.Remove(car);
        }
    }
}