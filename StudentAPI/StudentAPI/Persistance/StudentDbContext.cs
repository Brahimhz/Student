using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.Models;

namespace StudentAPI.Persistance
{
    public class StudentDbContext : DbContext
    {
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Seance> Seances { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {

        }
    }
}
