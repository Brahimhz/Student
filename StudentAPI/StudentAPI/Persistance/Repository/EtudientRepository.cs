using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class EtudientRepository : IEtudiantRepository
    {
        private readonly StudentDbContext context;

        public EtudientRepository(StudentDbContext context)
        {
            this.context = context;
        }

        public void Add(Etudiant etudiant)
        {
            context.Etudiants.Add(etudiant);
        }
        public void Remove(Etudiant etudiant)
        {
            context.Etudiants.Remove(etudiant);
        }


        public async Task<Etudiant> GetEtudiant(int id, bool eagerLoading = true)
        {
            //  return await context.Personne.OfType<Etudiant>().SingleOrDefaultAsync(e => e.Id == id);

            return await context.Etudiants.FindAsync(id);

        }

        public async Task<QueryResult<Etudiant>> GetEtudiants(EtudiantQuery filter)
        {
            throw new NotImplementedException();
        }

    }
}
