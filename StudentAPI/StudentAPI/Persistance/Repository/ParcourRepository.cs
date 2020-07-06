using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using StudentAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class ParcourRepository : GenericRepository<Parcour>, IParcourRepository
    {
        private readonly StudentDbContext _context;
        private readonly DbSet<Parcour> _dbSet;

        public ParcourRepository(StudentDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Parcour>();

        }
        public async Task<QueryResult<Parcour>> GetAll(ParcourQuery parcourQuery)
        {
            var result = new QueryResult<Parcour>();

            var query = _dbSet
                         .Include(p => p.Etudient)

                         .Include(p => p.NiveauSpecialite)
                              .ThenInclude(ns => ns.Specialite)
                                 .ThenInclude(s => s.Filiere)
                                     .ThenInclude(f => f.DomaineFormation)

                          .Include(p => p.SousGroupe)
                              .ThenInclude(sg => sg.PlanningSGroupes)
                                   .ThenInclude(psg => psg.PlanningGroupe)
                                        .ThenInclude(pg => pg.PlanningSection)

                          .Include(p => p.Resultat)

                          .AsQueryable();

            if (parcourQuery != null)
            {
                //Domaine De Formation Filter
                if (parcourQuery.DFId.HasValue)
                    query = query.Where(p => p.NiveauSpecialite.Specialite.Filiere.DomaineFormation.Id == parcourQuery.DFId);

                //Filiaire Filter
                if (parcourQuery.FiliaireId.HasValue)
                    query = query.Where(p => p.NiveauSpecialite.Specialite.Filiere.Id == parcourQuery.FiliaireId);

                //Specialite Filter
                if (parcourQuery.SpecialiteId.HasValue)
                    query = query.Where(p => p.NiveauSpecialite.Specialite.Id == parcourQuery.SpecialiteId);

                //Niveau de Specialite Filter
                if (parcourQuery.NivSpecId.HasValue)
                    query = query.Where(p => p.NiveauSpecialite.Id == parcourQuery.NivSpecId);


                var columnMap = new Dictionary<string, Expression<Func<Parcour, object>>>()
                {

                    ["nomEtudient"] = p => p.Etudient.Nom,
                    ["prenomEtudient"] = p => p.Etudient.Prenom,
                    ["nomSpecialite"] = p => p.NiveauSpecialite.Specialite.NomSpecialite


                };


                query = query.ApplyOrdering(parcourQuery, columnMap);

                result.TotalItems = await query.CountAsync();

                query = query.ApplyPaging(parcourQuery);

                result.Items = await query.ToListAsync();

                return result;
            }
            else
            {
                result.TotalItems = await query.CountAsync();
                result.Items = await query.ToListAsync();

                return result;
            }
        }
        public async Task<Parcour> GetByIdFull(int id)
        {
            return await _dbSet

                          .Include(p => p.Etudient)

                          .Include(p => p.NiveauSpecialite)
                               .ThenInclude(ns => ns.Specialite)
                                  .ThenInclude(s => s.Filiere)
                                      .ThenInclude(f => f.DomaineFormation)

                          .Include(p => p.SousGroupe)
                               .ThenInclude(sg => sg.PlanningSGroupes)
                                    .ThenInclude(psg => psg.PlanningGroupe)
                                         .ThenInclude(pg => pg.PlanningSection)

                           .Include(p => p.Resultat)

                      .SingleOrDefaultAsync(p => p.Id == id);


        }
    }
}
