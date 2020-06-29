using StudentAPI.Controllers.Resources.NiveauSpecialite;
using StudentAPI.Controllers.Resources.Query;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface INiveauSpecialiteAppService : IGenericAppService<NiveauSpecialite, NiveauSpecialiteResource, NiveauSpecialiteResource>
    {
        Task<QueryResultResource<NiveauSpecialiteResource>> GetAll(NiveauSpecialiteQueryResource filterResource);

    }
}
