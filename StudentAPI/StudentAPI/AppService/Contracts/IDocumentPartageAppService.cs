using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;

namespace StudentAPI.AppService.Contracts
{
    public interface IDocumentPartageAppService : IGenericAppService<DocumentPartage, GetDocumentPartageResource, SetDocumentPartageResource, RequestQuery>
    {

    }
}
