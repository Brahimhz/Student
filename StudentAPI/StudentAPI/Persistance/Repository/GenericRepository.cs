using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using StudentAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class GenericRepository<T> : IRepository<T> where T:class
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
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }


        public async Task<T> GetById(int id, bool eagerLoading = true)
        {
            //  return await context.Personne.OfType<Etudiant>().SingleOrDefaultAsync(e => e.Id == id);

            return await _dbSet.FindAsync(id);

        }

        public async Task<QueryResult<T>> GetAll(IQueryObject filter)
        {
            throw new NotImplementedException();
        }
    }
}
