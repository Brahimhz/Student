using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class SeanceRepository : ISeanceRepository
    {
        private StudentDbContext context;

        public SeanceRepository(StudentDbContext context)
        {
            this.context = context;
        }

        public void Add(Seance seance)
        {
            context.Seances.Add(seance);
        }


        public void Remove(Seance seance)
        {
            context.Seances.Remove(seance);
        }


        public async Task<Seance> GetSeance(int id, bool eagerLoading = true)
        {
            return await context.Seances.FindAsync(id);
        }


    }
}
