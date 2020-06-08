using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IEtudiantRepository : IGenericRepository<Etudiant>
    {
        Task<Etudiant> GetByMatricule(string matricule);
    }
}
