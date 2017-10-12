using System.Threading.Tasks;

namespace RallyeTime.Persistence
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}