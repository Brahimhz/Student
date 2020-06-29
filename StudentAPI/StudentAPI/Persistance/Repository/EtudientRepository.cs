using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class EtudientRepository : GenericRepository<Etudiant>, IEtudiantRepository
    {
        private readonly StudentDbContext _context;

        public EtudientRepository(StudentDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Etudiant>> GetAll()
        {
            return await _context.Etudiants.ToListAsync();
        }

        public async Task<Etudiant> GetByMatricule(string matricule)
        {
            return await _context.Etudiants.SingleOrDefaultAsync(x => x.Matricule == matricule);
        }
    }
}
