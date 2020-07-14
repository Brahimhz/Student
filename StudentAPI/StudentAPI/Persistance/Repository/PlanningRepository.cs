using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class PlanningRepository : IPlanningRepository
    {
        private StudentDbContext _context;
        private DbSet<PlanningSection> _dbSetPSection;
        private DbSet<PlanningGroupe> _dbSetGroupe;
        private DbSet<PlanningSGroupe> _dbSetSGroupe;
        private DbSet<Section> _dbSetSection;

        public PlanningRepository(StudentDbContext context)
        {
            _context = context;
            _dbSetPSection = _context.Set<PlanningSection>();
            _dbSetGroupe = _context.Set<PlanningGroupe>();
            _dbSetSGroupe = _context.Set<PlanningSGroupe>();
            _dbSetSection = _context.Set<Section>();

        }

        public async Task<Section> GetBySectionId(int sectionId)
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

        public async Task<PlanningGroupe> GetPlanningGroupeById(int id)
        {
            return await _dbSetGroupe

                            .Include(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Enseignat)

                            .Include(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Journee)

                            .Include(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Salle)
                                    .ThenInclude(s => s.Bloc)

                            .Include(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Seance)

                            .Include(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Matiere)
                                    .ThenInclude(m => m.MatiereRef)
                            .Include(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Matiere)
                                    .ThenInclude(m => m.UnitePedagogique)

                            .SingleOrDefaultAsync(pg => pg.Id == id);
        }

        public async Task<PlanningSection> GetPlanningSectionById(int id)
        {
            return await _dbSetPSection

                            .Include(ps => ps.InfoSeances)
                                .ThenInclude(inse => inse.Enseignat)

                            .Include(ps => ps.InfoSeances)
                                .ThenInclude(inse => inse.Journee)

                            .Include(ps => ps.InfoSeances)
                                .ThenInclude(inse => inse.Salle)
                                    .ThenInclude(s => s.Bloc)

                            .Include(ps => ps.InfoSeances)
                                .ThenInclude(inse => inse.Seance)

                            .Include(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Matiere)
                                    .ThenInclude(m => m.MatiereRef)
                            .Include(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Matiere)
                                    .ThenInclude(m => m.UnitePedagogique)

                            .SingleOrDefaultAsync(ps => ps.Id == id);
        }

        public async Task<PlanningSGroupe> GetPlanningSGroupeById(int id)
        {
            return await _dbSetSGroupe

                            .Include(psg => psg.InfoSeances)
                                .ThenInclude(inse => inse.Enseignat)

                            .Include(psg => psg.InfoSeances)
                                .ThenInclude(inse => inse.Journee)

                            .Include(psg => psg.InfoSeances)
                                .ThenInclude(inse => inse.Salle)
                                    .ThenInclude(s => s.Bloc)

                            .Include(psg => psg.InfoSeances)
                                .ThenInclude(inse => inse.Seance)

                            .Include(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Matiere)
                                    .ThenInclude(m => m.MatiereRef)
                            .Include(pg => pg.InfoSeances)
                                .ThenInclude(inse => inse.Matiere)
                                    .ThenInclude(m => m.UnitePedagogique)

                            .SingleOrDefaultAsync(psg => psg.Id == id);
        }
    }
}
