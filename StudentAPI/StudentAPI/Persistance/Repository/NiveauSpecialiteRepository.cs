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
    public class NiveauSpecialiteRepository : GenericRepository<NiveauSpecialite>, INiveauSpecialiteRepository
    {
        private readonly StudentDbContext _context;
        private readonly DbSet<NiveauSpecialite> _dbSet;


        public NiveauSpecialiteRepository(StudentDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<NiveauSpecialite>();

        }

        public async Task<QueryResult<NiveauSpecialite>> GetAll(NiveauSpecialiteQuery niveauSpecialiteQuery)
        {

            var result = new QueryResult<NiveauSpecialite>();
            result.TotalItems = 0;
            result.Items = new List<NiveauSpecialite>();


            if (niveauSpecialiteQuery.DFId == null || niveauSpecialiteQuery.FiliaireId == null || niveauSpecialiteQuery.SpecialiteId == null)
                return result;
            else
            {
                var query = _dbSet
                               .Include(ns => ns.Specialite)
                                  .ThenInclude(s => s.Filiere)
                                    .ThenInclude(f => f.DomaineFormation)
                          .AsQueryable();

                query = query.Where(ns => ns.Specialite.Filiere.DomaineFormation.Id == niveauSpecialiteQuery.DFId
                                        && ns.Specialite.Filiere.Id == niveauSpecialiteQuery.FiliaireId
                                        && ns.Specialite.Id == niveauSpecialiteQuery.SpecialiteId);

                var columnMap = new Dictionary<string, Expression<Func<NiveauSpecialite, object>>>()
                {

                    ["niveau"] = dp => dp.Niveau

                };


                query = query.ApplyOrdering(niveauSpecialiteQuery, columnMap);

                result.TotalItems = await query.CountAsync();

                query = query.ApplyPaging(niveauSpecialiteQuery);

                result.Items = await query.ToListAsync();

                return result;

            }
        }


    }
}
