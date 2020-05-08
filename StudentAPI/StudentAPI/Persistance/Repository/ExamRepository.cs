using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using System.Threading.Tasks;

namespace StudentAPI.Persistance.Repository
{
    public class ExamRepository : IExamRepository
    {
        private StudentDbContext context;

        public ExamRepository(StudentDbContext context)
        {
            this.context = context;
        }

        public void Add(Exam exam)
        {
            context.Exams.Add(exam);
        }

        public void Remove(Exam exam)
        {
            context.Exams.Remove(exam);
        }

        public async Task<Exam> GetExam(int id, bool eagerLoading = true)
        {
            if (!eagerLoading)
                return await context.Exams.FindAsync(id);

            return await context.Exams
                            .Include(e => e.Module)
                            .SingleOrDefaultAsync(e => e.Id == id);
        }


    }
}
