using System.Collections.Generic;
using System.Threading.Tasks;
using RallyeTime.Models;

namespace RallyeTime.Persistence
{
    public interface ICarRepository
    {
         Task<Car> GetCar(int id);
         void Add(Car car);
         void Remove(Car car);
         Task<List<Car>> GetAllCars();
    }
}