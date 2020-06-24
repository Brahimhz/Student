using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface ISectionRepository : IGenericRepository<Section>
    {
        Task<QueryResult<Section>> GetAll(SectionQuery sectionQuery);

    }
}
