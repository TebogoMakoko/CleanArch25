using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Data.Context
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
    }
}
