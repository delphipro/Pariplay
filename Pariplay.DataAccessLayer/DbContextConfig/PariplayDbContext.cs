using Microsoft.EntityFrameworkCore;
using Pariplay.DataAccessLayer.DataObjects;

namespace Pariplay.DataAccessLayer.DbContextConfig
{
    public class PariplayDbContext: DbContext
    {
        public PariplayDbContext(string connectionString) : base(GetOptions(connectionString)){}

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }

        public DbSet<MatchDTO> Match { get; set; }

        public DbSet<ActualResultDTO> ActualResult { get; set; }

        public DbSet<TeamDTO> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MatchDTO>()
                .Property(x => x.CreatedTimestamp)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<TeamDTO>()
                .Property(x => x.CreatedTimestamp)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<TeamDTO>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<ActualResultDTO>()
                .Property(x => x.CreatedTimestamp)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ActualResultDTO>()
                .Property(x => x.UpdatedTimestamp)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<MatchDTO>()
                .HasOne(x => x.Host)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MatchDTO>()
                .HasOne(x => x.Visitor)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
