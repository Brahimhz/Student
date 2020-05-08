using StudentAPI.Core.Models;
using StudentAPI.Core.Models.Query;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IExamTableRepository
    {
        Task<ExamTable> GetExamTable(int id, bool eagerLoading = true);

        void AddExamTable(ExamTable examTable);
        void RemoveExamTable(ExamTable examTable);

        Task<QueryResult<ExamTable>> GetExamTables(SchoolInformationQuery queryObj);
    }
}
