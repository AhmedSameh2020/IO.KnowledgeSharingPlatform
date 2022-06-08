using CsvHelper;
using IO.KnowledgeSharingPlatform.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace IO.KnowledgeSharingPlatform.Infrastructure.Repository
{
    public class KnowledgeSharingPlatformContext : DbContext
    {
        public KnowledgeSharingPlatformContext(DbContextOptions<KnowledgeSharingPlatformContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TedTalk> TedTalks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TedTalk>().HasKey(a => a.Id);
            using (var reader = new StreamReader("SeedData\\data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var tedTalks = csv.GetRecords<TedTalk>();
                foreach (var tedTalk in tedTalks)
                {
                    tedTalk.Id = Guid.NewGuid();
                }
                modelBuilder.Entity<TedTalk>().HasData(tedTalks);
            }
        }
    }
}
