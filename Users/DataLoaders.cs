using Microsoft.EntityFrameworkCore;

namespace Users
{
    internal static class DataLoaders
    {
        [DataLoader]
        public static async Task<IReadOnlyDictionary<Guid, UserEntity>> GetUserByIdAsync(
            IReadOnlyList<Guid> ids,
            UsersContext db,
            CancellationToken cancellationToken)
        {
            return await db.Users.Where(f => ids.Contains(f.Id)).ToDictionaryAsync(f => f.Id,cancellationToken);
        }
    }
}
