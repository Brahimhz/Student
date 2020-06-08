using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);

        void Add(T entity);
        void Remove(int id);
    }
}
