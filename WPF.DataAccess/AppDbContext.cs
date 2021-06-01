using Microsoft.EntityFrameworkCore;
using WPF.Model;

namespace WPF.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public DbSet<Entity> Entities { get; set; }

        public DbSet<TrackRecord> TrackRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=AIRLBEOF11958\\SYNTRA;Initial Catalog=WPFExamen;Integrated Security=True");

            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
  

