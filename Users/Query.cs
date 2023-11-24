using Microsoft.EntityFrameworkCore;

namespace Users
{
    [QueryType]
    public static class Query
    {
        [UseOffsetPaging]
        public static IQueryable<User> GetUsers([Service] UsersContext db)
        {
            return db.Users;
        }

        [NodeResolver]
        public static async Task<User?> GetUserById(
            Guid id,
            UserByIdDataLoader loader,
            CancellationToken cancellationToken
            )
        {
            return await loader.LoadAsync(id,cancellationToken);
        }

    }

    [ExtendObjectType<User>]
    public static class UserNode
    {

        [DataLoader]
        public static async Task<IReadOnlyDictionary<Guid, User>> GetUserByIdAsync(
            IReadOnlyList<Guid> ids,
            UsersContext db,
            CancellationToken cancellationToken)
        {
            var idss = ids.ToArray();
            return await db.Users.Where(f => idss.Contains(f.Id)).ToDictionaryAsync(f => f.Id, cancellationToken);
        }

    }


}
