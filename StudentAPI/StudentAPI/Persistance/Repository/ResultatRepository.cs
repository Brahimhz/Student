using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class ResultatRepository : GenericRepository<Resultat>, IResultatRepository
    {
        private readonly StudentDbContext _context;
        private readonly DbSet<Resultat> _dbSetResultat;
        private readonly DbSet<UnitePedagogique> _dbSetUnite;
        private readonly DbSet<Matiere> _dbSetMatiere;
        private readonly DbSet<Parcour> _dbSetParcour;


        public ResultatRepository(StudentDbContext context) : base(context)
        {
            _context = context;
            _dbSetResultat = _context.Set<Resultat>();
            _dbSetUnite = _context.Set<UnitePedagogique>();
            _dbSetParcour = _context.Set<Parcour>();
            _dbSetMatiere = _context.Set<Matiere>();

        }

        public async Task<Resultat> GetByIdFull(int id)
        {
            return await _dbSetResultat

                            .Include(r => r.ResultatUnites)
                                .ThenInclude(ru => ru.ResultatMatieres)
                                    .ThenInclude(rm => rm.Matiere)
                                        .ThenInclude(m => m.MatiereRef)

                            .Include(r => r.ResultatUnites)
                                .ThenInclude(ru => ru.UnitePedagogique)



                    .SingleOrDefaultAsync(r => r.Id == id);


        }

        public async Task<Dictionary<int, List<Matiere>>> GetResultatModel(int idParcour)
        {
            var idNS = (await _dbSetParcour.SingleOrDefaultAsync(p => p.Id == idParcour)).NiveauSpecialiteId;

            var uniteNS = await _dbSetUnite.Select(u => u.Id).ToListAsync();

            var matiereNS = await _dbSetMatiere
                            .Where(m => m.NiveauSpecialiteId == idNS)
                            .ToListAsync();

            var resultatModel = new Dictionary<int, List<Matiere>>();


            foreach (int uniteId in uniteNS)
            {
                var matiereUnite = matiereNS.Where(m => m.UnitePedagogiqueId == uniteId).ToList();

                resultatModel.Add(uniteId, matiereUnite);
            }


            return resultatModel;
        }


    }
}
