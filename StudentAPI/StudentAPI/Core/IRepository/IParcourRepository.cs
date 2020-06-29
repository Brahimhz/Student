using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IParcourRepository : IGenericRepository<Parcour>
    {
        Task<Parcour> GetByIdFull(int id);
        Task<QueryResult<Parcour>> GetAll(ParcourQuery parcourQuery);
    }
}
