using System.Threading.Tasks;

namespace StudentAPI.AppService
{
    public interface IGenericAppService<T, TGetResource, TSetResource>
        where T : class
    {
        Task<TGetResource> GetById(int id);

        Task<TGetResource> Add(TSetResource entity);
        Task<TGetResource> Update(int id, TSetResource entity);
        Task<int> Remove(int id);
    }
}
