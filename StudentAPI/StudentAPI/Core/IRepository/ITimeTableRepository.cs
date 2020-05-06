using StudentAPI.Core.Models;
using StudentAPI.Core.Models.Query;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface ITimeTableRepository
    {
        Task<TimeTable> GetTimeTable(int id, bool eagerLoading = true);

        void AddTimeTable(TimeTable timeTable);
        void RemoveTimeTable(TimeTable timeTable);

        Task<QueryResult<TimeTable>> GetTimeTables(SchoolInformationQuery queryObj);
    }
}
