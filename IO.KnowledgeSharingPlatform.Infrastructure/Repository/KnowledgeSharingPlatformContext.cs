using IO.KnowledgeSharingPlatform.Core.Model;
using Microsoft.EntityFrameworkCore;

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
        }
    }
}
