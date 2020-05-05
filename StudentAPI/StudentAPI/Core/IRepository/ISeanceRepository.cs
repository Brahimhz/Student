using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface ISeanceRepository
    {
        Task<Seance> GetSeance(int id, bool eagerLoading = true);

        void Add(Seance seance);
        void Remove(Seance seance);

    }
}
