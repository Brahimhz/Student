using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudentAPI.Core.Models
{
    public class ExamTable : SchoolInformation
    {
        public ICollection<Exam> Exams { get; set; }

        public ExamTable()
        {
            Exams = new Collection<Exam>();
        }

    }
}
