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
    public class DocumentPartageRepository : GenericRepository<DocumentPartage>, IDocumentPartageRepository
    {
        private readonly StudentDbContext _context;
        private readonly DbSet<DocumentPartage> _dbSet;


        public DocumentPartageRepository(StudentDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<DocumentPartage>();

        }


        public async Task<QueryResult<DocumentPartage>> GetAll(DocumentPartageQuery documentPartageQuery)
        {
            var result = new QueryResult<DocumentPartage>();

            var query = _dbSet
                          .Include(dp => dp.NiveauSpecialite)
                              .ThenInclude(ns => ns.Specialite)
                                 .ThenInclude(s => s.Filiere)
                                     .ThenInclude(f => f.DomaineFormation)
                          .Include(dp => dp.Personne)
                          .Include(dp => dp.MatiereRef)
                          .AsQueryable();

            if (documentPartageQuery != null)
            {
                //Domaine De Formation Filter
                if (documentPartageQuery.DFId.HasValue)
                    query = query.Where(dp => dp.NiveauSpecialite.Specialite.Filiere.DomaineFormation.Id == documentPartageQuery.DFId);

                //Filiaire Filter
                if (documentPartageQuery.FiliaireId.HasValue)
                    query = query.Where(dp => dp.NiveauSpecialite.Specialite.Filiere.Id == documentPartageQuery.FiliaireId);

                //Specialite Filter
                if (documentPartageQuery.SpecialiteId.HasValue)
                    query = query.Where(dp => dp.NiveauSpecialite.Specialite.Id == documentPartageQuery.SpecialiteId);

                //Niveau de Specialite Filter
                if (documentPartageQuery.NivSpecId.HasValue)
                    query = query.Where(dp => dp.NiveauSpecialite.Id == documentPartageQuery.NivSpecId);

                //Matiere Filter
                if (documentPartageQuery.MatierRefId.HasValue)
                    query = query.Where(dp => dp.MatiereRef.Id == documentPartageQuery.MatierRefId);

                var columnMap = new Dictionary<string, Expression<Func<DocumentPartage, object>>>()
                {

                    ["nomdoc"] = dp => dp.NomDoc,
                    ["typedoc"] = dp => dp.TypeDoc,
                    ["editdoc"] = dp => dp.Personne.Nom,

                };


                query = query.ApplyOrdering(documentPartageQuery, columnMap);

                result.TotalItems = await query.CountAsync();

                query = query.ApplyPaging(documentPartageQuery);

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

        public async Task<DocumentPartage> GetByIdFull(int id)
        {
            return await _dbSet
                        .Include(dp => dp.Document)
                        .Include(dp => dp.MatiereRef)
                        .Include(dp => dp.Personne)
                        .Include(dp => dp.NiveauSpecialite)
                             .ThenInclude(ns => ns.Specialite)
                                .ThenInclude(s => s.Filiere)
                                    .ThenInclude(f => f.DomaineFormation)

                        .SingleOrDefaultAsync(dp => dp.Id == id);
        }

    }
}
