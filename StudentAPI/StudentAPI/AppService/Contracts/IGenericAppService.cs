using StudentAPI.Core.Models;
using StudentAPI.Extensions;
using System.Threading.Tasks;

namespace StudentAPI.AppService
{
    public interface IGenericAppService<T, TGetResource, TSetResource, TQueryObject>
        where TQueryObject : IQueryObject
    {
        Task<TGetResource> GetById(int id, bool eagerLoading = true);
        Task<QueryResult<TGetResource>> GetAll(TQueryObject filter);

        Task<TGetResource> Add(TSetResource entity);
        Task<TGetResource> Update(int id, TSetResource entity);
        void Remove(int id);
    }
}
