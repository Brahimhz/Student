using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Persistance
{
    public class StudentDbContext : DbContext
    {


        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
