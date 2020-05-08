﻿using Microsoft.EntityFrameworkCore;
using StudentAPI.Core.Models;

namespace StudentAPI.Persistance
{
    public class StudentDbContext : DbContext
    {
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ExamTable> ExamTables { get; set; }
        public DbSet<Exam> Exams { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>()
                .Ignore(m => m.SchoolYear)
                .Ignore(m => m.ClassNbr);

            modelBuilder.Entity<Seance>()
                .HasAlternateKey(s => new { s.TimeTableId, s.Day, s.Time });

            modelBuilder.Entity<Exam>()
                .HasAlternateKey(e => new { e.ExamTableId, e.Date, e.Time });
        }
    }
}