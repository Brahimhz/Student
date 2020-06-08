using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StudentDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(StudentDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Remove(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }


        public async Task<T> GetById(int id)
        {

            return await _dbSet.FindAsync(id);

        }

    }
}
