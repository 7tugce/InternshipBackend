using InternshipBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }   
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
    }
}
