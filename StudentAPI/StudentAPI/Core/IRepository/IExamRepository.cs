using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Core.IRepository
{
    public interface IExamRepository
    {
        Task<Exam> GetExam(int id, bool eagerLoading = true);

        void Add(Exam exam);
        void Remove(Exam exam);
    }
}
