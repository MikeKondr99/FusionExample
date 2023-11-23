using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Data;
using System.Linq.Expressions;

namespace Files
{
    public class FileEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public Guid UserId { get; set; }
        public required UpperCaseString Sign { get; set; }
        public required byte[] Blob { get; set; }
    }

    public class FilesContext : DbContext
    {

        public FilesContext(DbContextOptions options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<FileEntity> Files => Set<FileEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileEntity>().Property(f => f.Sign)
                .HasConversion(new UpperCaseStringConverter());
            base.OnModelCreating(modelBuilder);
        }
    }
}
