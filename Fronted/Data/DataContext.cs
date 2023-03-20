using Microsoft.EntityFrameworkCore;
using Fronted.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Metadata;

namespace Fronted.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<MaliciousEvent> MaliciousEvents { get; set; }
        public DbSet<PlatformType> PlatformTypes { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<AssessmentReport> AssessmentReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MaliciousEvent>()
                            .Property(m => m.VisitedAt)
                            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<MaliciousEvent>()
                            .Property(t => t.ThreatLevel)
                            .HasConversion(
                                v => v.ToString(),
                                v => (ThreatLevel)Enum.Parse(typeof(ThreatLevel), v));

            modelBuilder.Entity<AssessmentReport>()
                            .Property(a => a.ThreatType)
                            .HasConversion(
                                v => v.ToString(),
                                v => (ThreatType)Enum.Parse(typeof(ThreatType), v));
        }
    }
}
