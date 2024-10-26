using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.Entity<Task>(

                    entity =>
                    {
                        entity.ToTable("tasks");
                        entity.HasKey(e => e.Id);
                        entity.Property(e => e.Id)
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()")
                        .ValueGeneratedOnAdd();
                        entity.Property(entity => entity.Title).IsRequired().HasMaxLength(100);
                        entity.Property(entity => entity.Description).IsRequired().HasMaxLength(200);
                        entity.Property(entity => entity.Deadline).IsRequired();
                        entity.Property(entity => entity.CreatedAt).IsRequired();
                    }
                );
        }
    }
}
