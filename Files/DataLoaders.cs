using Microsoft.EntityFrameworkCore;

namespace Files
{
    internal static class DataLoaders
    {
        [DataLoader]
        public static async Task<IReadOnlyDictionary<Guid, FileEntity>> GetFileByIdAsync(
            IReadOnlyList<Guid> ids,
            FilesContext db,
            CancellationToken cancellationToken)
        {
            return await db.Files.Where(f => ids.Contains(f.Id)).ToDictionaryAsync(f => f.Id,cancellationToken);
        }
    }
}
