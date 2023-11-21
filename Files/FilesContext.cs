using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Files
{
    public class FileEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public Guid UserId { get; set; }
    }

    public class FilesContext : DbContext
    {

        public FilesContext(DbContextOptions options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<FileEntity> Files => Set<FileEntity>();
    }
}
