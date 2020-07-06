using StudentAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IResultatRepository : IGenericRepository<Resultat>
    {
        Task<Resultat> GetByIdFull(int id);
        Task<Dictionary<int, List<Matiere>>> GetResultatModel(int idParcour);



    }
}
