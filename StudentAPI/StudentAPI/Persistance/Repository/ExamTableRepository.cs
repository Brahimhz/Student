using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.Models.Query;
using StudentAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class ExamTableRepository : IExamTableRepository
    {
        private StudentDbContext context;

        public ExamTableRepository(StudentDbContext context)
        {
            this.context = context;
        }



        public void AddExamTable(ExamTable examTable)
        {
            context.ExamTables.Add(examTable);
        }

        public void RemoveExamTable(ExamTable examTable)
        {
            context.ExamTables.Remove(examTable);
        }


        public async Task<ExamTable> GetExamTable(int id, bool eagerLoading = true)
        {
            if (!eagerLoading)
                return await context.ExamTables.FindAsync(id);

            return await context.ExamTables
                        .Include(e => e.Exams)
                        .ThenInclude(e => e.Module)
                        .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<QueryResult<ExamTable>> GetExamTables(SchoolInformationQuery queryObj)
        {
            var result = new QueryResult<ExamTable>();

            var query = context
                        .ExamTables
                        .Include(e => e.Exams)
                            .ThenInclude(e => e.Module)
                        .AsQueryable();


            //Filters

            if (!string.IsNullOrEmpty(queryObj.SchoolYear))
                query = query.Where(t => t.SchoolYear.Equals(queryObj.SchoolYear));

            if (!string.IsNullOrEmpty(queryObj.Cycle))
                query = query.Where(t => t.Cycle.Equals(queryObj.Cycle));

            if (!string.IsNullOrEmpty(queryObj.Semester))
                query = query.Where(t => t.Semester.Equals(queryObj.Semester));

            if (!string.IsNullOrEmpty(queryObj.Speciality))
                query = query.Where(t => t.Speciality.Equals(queryObj.Speciality));

            if (!string.IsNullOrEmpty(queryObj.ClassNbr))
                query = query.Where(t => t.ClassNbr.Equals(queryObj.ClassNbr));


            var columnMap = new Dictionary<string, Expression<Func<ExamTable, object>>>()
            {

                ["schoolYear"] = e => e.SchoolYear,
                ["cycle"] = e => e.Cycle,
                ["semester"] = e => e.Semester,
                ["speciality"] = e => e.Speciality,
                ["classNbr"] = e => e.ClassNbr,
                ["id"] = e => e.Id

            };

            query = query.ApplyOrdering(queryObj, columnMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }


    }
}
