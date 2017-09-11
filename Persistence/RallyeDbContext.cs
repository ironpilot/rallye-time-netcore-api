using Microsoft.EntityFrameworkCore;
using RallyeTime.Models;

namespace RallyeTime.Persistence
{
    public class RallyeDbContext : DbContext
    {
        public RallyeDbContext(DbContextOptions<RallyeDbContext> options) : base(options)
        {
            
        }
        public DbSet<Race> Races { get; set; }
        public DbSet<Checkpoint> Checkpoints { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
    }
}