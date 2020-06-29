using StudentAPI.Controllers.Resources.Parcour;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface IParcourAppService : IGenericAppService<Parcour, GetParcourResource, SetParcourResource>
    {
        Task<QueryResultResource<GetParcourResource>> GetAll(ParcourQueryResource filterResource);
        Task<GetParcourResource> GetByIdFull(int id);
    }
}
