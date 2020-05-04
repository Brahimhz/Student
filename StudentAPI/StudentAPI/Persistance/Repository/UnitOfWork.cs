using StudentAPI.Core.IRepository;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private StudentDbContext context;

        public UnitOfWork(StudentDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
