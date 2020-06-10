using StudentAPI.Extensions;
using System.Threading.Tasks;

namespace StudentAPI.AppService
{
    public interface IGenericAppService<T, TGetResource, TSetResource, TQueryObject>
        where T : class
        where TQueryObject : IQueryObject
    {
        Task<TGetResource> GetById(int id, bool eagerLoading = true);

        Task<TGetResource> Add(TSetResource entity);
        Task<TGetResource> Update(int id, TSetResource entity);
        void Remove(int id);
    }
}
