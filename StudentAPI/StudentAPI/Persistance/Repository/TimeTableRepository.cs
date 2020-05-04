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
    public class TimeTableRepository : ITimeTableRepository
    {
        private StudentDbContext context;

        public TimeTableRepository(StudentDbContext context)
        {
            this.context = context;
        }

        public async Task<TimeTable> GetTimeTable(int id, bool eagerLoading = true)
        {
            if (!eagerLoading)
                return await context.TimeTables.FindAsync(id);

            return await context.TimeTables
                        .Include(t => t.Seances)
                        .SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<QueryResult<TimeTable>> GetTimeTables(TimeTableQuery queryObj)
        {
            var result = new QueryResult<TimeTable>();

            var query = context
                        .TimeTables
                        .Include(t => t.Seances)
                        .AsQueryable();


            //Filters

            if (!string.IsNullOrEmpty(queryObj.SchoolYear))
                query = query.Where(t => t.SchoolYear.Equals(queryObj.SchoolYear));

            if (!string.IsNullOrEmpty(queryObj.Cycle))
                query = query.Where(t => t.Cycle.Equals(queryObj.Cycle));

            if (!string.IsNullOrEmpty(queryObj.Semester))
                query = query.Where(t => t.Semester.Equals(queryObj.Semester));

            if (!string.IsNullOrEmpty(queryObj.Specility))
                query = query.Where(t => t.Specility.Equals(queryObj.Specility));

            if (!string.IsNullOrEmpty(queryObj.ClassNbr))
                query = query.Where(t => t.ClassNbr.Equals(queryObj.ClassNbr));


            var columnMap = new Dictionary<string, Expression<Func<TimeTable, object>>>()
            {

                ["schoolYear"] = t => t.SchoolYear,
                ["cycle"] = t => t.Cycle,
                ["semester"] = t => t.Semester,
                ["specility"] = t => t.Specility,
                ["classNbr"] = t => t.ClassNbr,
                ["id"] = t => t.Id

            };

            query = query.ApplyOrdering(queryObj, columnMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;

        }

        public void RemoveTimeTable(TimeTable timeTable)
        {
            context.Remove(timeTable);
        }
        public void AddTimeTable(TimeTable timeTable)
        {
            context.TimeTables.Add(timeTable);
        }

    }
}
