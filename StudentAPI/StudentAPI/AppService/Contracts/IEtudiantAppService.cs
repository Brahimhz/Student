using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.AppService.Contracts
{
    public interface IEtudiantAppService : IGenericAppService<Etudiant, GetEtudiantResource, SetEtudiantResource>
    {
        Task<IEnumerable<GetEtudiantResource>> GetAll();
    }
}
