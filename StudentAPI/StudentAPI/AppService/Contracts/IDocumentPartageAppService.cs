using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface IDocumentPartageAppService : IGenericAppService<DocumentPartage, GetDocumentPartageResource, SetDocumentPartageResource>
    {
        Task<int> RemoveWithFile(int id);
        Task<QueryResultResource<GetDocumentPartageResource>> GetAllDP(DocumentPartageQueryResource filterResource);
        Task<GetDocumentPartageResource> GetByIdFull(int id);


    }
}
