using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
