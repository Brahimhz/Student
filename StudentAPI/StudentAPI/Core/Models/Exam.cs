using System;
using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Core.Models
{
    public class Exam
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(5)]
        public string Time { get; set; }
        public Module Module { get; set; }
        public int ModuleId { get; set; }
        public ExamTable ExamTable { get; set; }
        public int ExamTableId { get; set; }

    }
}
