using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class EtudientRepository : GenericRepository<Etudiant>, IEtudiantRepository
    {
        private readonly StudentDbContext context;

        public EtudientRepository(StudentDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Etudiant> GetByMatricule(string matricule)
        {
            return await context.Etudiants.SingleOrDefaultAsync(x => x.Matricule == matricule);
        }
    }
}
