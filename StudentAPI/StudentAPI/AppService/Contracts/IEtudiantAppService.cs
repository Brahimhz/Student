using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface IEtudiantAppService : IGenericAppService<Etudiant, GetEtudiantResource, SetEtudiantResource, DocumentPartageQuery>
    {
        Task<GetEtudiantResource> GetByMatricule(string matricule);
    }
}
