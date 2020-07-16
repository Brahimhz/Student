using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class PlanningRepository : IPlanningRepository
    {
        private StudentDbContext _context;
        private DbSet<Planning> _dbSetPlanning;

        private DbSet<PlanningSGroupe> _dbSetSGroupe;
        private DbSet<Section> _dbSetSection;

        public PlanningRepository(StudentDbContext context)
        {
            _context = context;
            _dbSetPlanning = _context.Set<Planning>();
            _dbSetSGroupe = _context.Set<PlanningSGroupe>();
            _dbSetSection = _context.Set<Section>();

        }

        public async Task<Section> GetFullBySectionId(int sectionId)
        {
            return await _dbSetSection
                    .Include(s => s.Groupes)
                        .ThenInclude(g => g.SousGroupes)

                    .SingleOrDefaultAsync(s => s.Id == sectionId);
        }

        public async Task<PlanningSGroupe> GetFullPlanningById(int id)
        {
            return await _dbSetSGroupe


                //GetPlanningSGroupeSeance
                .Include(psg => psg.InfoSeances)
                    .ThenInclude(inse => inse.Enseignat)

                .Include(psg => psg.InfoSeances)
                    .ThenInclude(inse => inse.Journee)

                .Include(psg => psg.InfoSeances)
                    .ThenInclude(inse => inse.Salle)

                .Include(psg => psg.InfoSeances)
                    .ThenInclude(inse => inse.Seance)

                .Include(pg => pg.InfoSeances)
                    .ThenInclude(inse => inse.Matiere)
                        .ThenInclude(m => m.MatiereRef)
                .Include(pg => pg.InfoSeances)
                    .ThenInclude(inse => inse.Matiere)
                        .ThenInclude(m => m.UnitePedagogique)


                //GetPlanningGroupeSeance

                .Include(psg => psg.PlanningGroupe)

                    .ThenInclude(pg => pg.InfoSeances)
                        .ThenInclude(inse => inse.Enseignat)

                .Include(psg => psg.PlanningGroupe)
                    .ThenInclude(pg => pg.InfoSeances)
                        .ThenInclude(inse => inse.Journee)


                .Include(psg => psg.PlanningGroupe)
                    .ThenInclude(pg => pg.InfoSeances)
                        .ThenInclude(inse => inse.Salle)

                .Include(psg => psg.PlanningGroupe)
                    .ThenInclude(pg => pg.InfoSeances)
                        .ThenInclude(inse => inse.Seance)

                .Include(psg => psg.PlanningGroupe)
                    .ThenInclude(pg => pg.InfoSeances)
                        .ThenInclude(inse => inse.Matiere)
                            .ThenInclude(m => m.MatiereRef)
                .Include(psg => psg.PlanningGroupe)
                    .ThenInclude(pg => pg.InfoSeances)
                        .ThenInclude(inse => inse.Matiere)
                            .ThenInclude(m => m.UnitePedagogique)


                        //GetPlanningGroupeSeance

                        .Include(psg => psg.PlanningGroupe)
                            .ThenInclude(pg => pg.PlanningSection)
                                .ThenInclude(ps => ps.InfoSeances)
                                    .ThenInclude(inse => inse.Enseignat)

                        .Include(psg => psg.PlanningGroupe)
                        .ThenInclude(pg => pg.PlanningSection)
                            .ThenInclude(ps => ps.InfoSeances)
                                .ThenInclude(inse => inse.Journee)

                        .Include(psg => psg.PlanningGroupe)
                        .ThenInclude(pg => pg.PlanningSection)
                            .ThenInclude(ps => ps.InfoSeances)
                                .ThenInclude(inse => inse.Salle)

                        .Include(psg => psg.PlanningGroupe)
                        .ThenInclude(pg => pg.PlanningSection)
                            .ThenInclude(ps => ps.InfoSeances)
                                .ThenInclude(inse => inse.Seance)

                        .Include(psg => psg.PlanningGroupe)
                           .ThenInclude(pg => pg.PlanningSection)
                            .ThenInclude(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Matiere)
                                    .ThenInclude(m => m.MatiereRef)
                        .Include(psg => psg.PlanningGroupe)
                          .ThenInclude(pg => pg.PlanningSection)
                            .ThenInclude(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Matiere)
                                    .ThenInclude(m => m.UnitePedagogique)



                .SingleOrDefaultAsync(psg => psg.Id == id);
        }

        public async Task<Planning> GetPlanningById(int id)
        {
            return await _dbSetPlanning

                            .Include(p => p.InfoSeances)
                                .ThenInclude(inse => inse.Enseignat)

                            .Include(p => p.InfoSeances)
                                .ThenInclude(inse => inse.Journee)

                            .Include(p => p.InfoSeances)
                                .ThenInclude(inse => inse.Salle)
                                    .ThenInclude(s => s.Bloc)

                            .Include(p => p.InfoSeances)
                                .ThenInclude(inse => inse.Seance)

                            .Include(p => p.InfoSeances)
                                .ThenInclude(inse => inse.Matiere)
                                    .ThenInclude(m => m.MatiereRef)
                            .Include(p => p.InfoSeances)
                                .ThenInclude(inse => inse.Matiere)
                                    .ThenInclude(m => m.UnitePedagogique)

                            .SingleOrDefaultAsync(p => p.Id == id);
        }


    }
}
