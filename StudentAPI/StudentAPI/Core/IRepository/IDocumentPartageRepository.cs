using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IDocumentPartageRepository : IGenericRepository<DocumentPartage>
    {
        Task<DocumentPartage> GetByIdFull(int id);
        Task<QueryResult<DocumentPartage>> GetAll(DocumentPartageQuery documentPartageQuery);

    }
}
