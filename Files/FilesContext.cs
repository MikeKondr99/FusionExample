using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq.Expressions;

namespace Files
{
    public class File
    {
        [Key]
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

        public DbSet<File> Files => Set<File>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>().Property(f => f.Sign)
                .HasConversion(new UpperCaseStringConverter());
            base.OnModelCreating(modelBuilder);
        }
    }
}
