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
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        private readonly StudentDbContext _context;
        private readonly DbSet<Section> _dbSet;

        public SectionRepository(StudentDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Section>();
        }
        public async Task<QueryResult<Section>> GetAll(SectionQuery sectionQuery)
        {
            var result = new QueryResult<Section>();

            var query = _dbSet
                          .Include(s => s.NiveauSpecialite)
                              .ThenInclude(ns => ns.Specialite)
                                 .ThenInclude(s => s.Filiere)
                                     .ThenInclude(f => f.DomaineFormation)

                          .Include(s => s.Groupes)
                            .ThenInclude(g => g.SousGroupes)
                          .AsQueryable();

            if (sectionQuery != null)
            {
                //Domaine De Formation Filter
                if (sectionQuery.DFId.HasValue)
                    query = query.Where(dp => dp.NiveauSpecialite.Specialite.Filiere.DomaineFormation.Id == sectionQuery.DFId);

                //Filiaire Filter
                if (sectionQuery.FiliaireId.HasValue)
                    query = query.Where(dp => dp.NiveauSpecialite.Specialite.Filiere.Id == sectionQuery.FiliaireId);

                //Specialite Filter
                if (sectionQuery.SpecialiteId.HasValue)
                    query = query.Where(dp => dp.NiveauSpecialite.Specialite.Id == sectionQuery.SpecialiteId);

                //Niveau de Specialite Filter
                if (sectionQuery.NivSpecId.HasValue)
                    query = query.Where(dp => dp.NiveauSpecialite.Id == sectionQuery.NivSpecId);


                var columnMap = new Dictionary<string, Expression<Func<Section, object>>>()
                {
                    ["refSection"] = s => s.RefSection
                };


                query = query.ApplyOrdering(sectionQuery, columnMap);

                result.TotalItems = await query.CountAsync();

                query = query.ApplyPaging(sectionQuery);

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
    }
}
