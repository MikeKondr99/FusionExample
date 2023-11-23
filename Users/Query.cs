namespace Users
{
    [QueryType]
    public static class Query
    {
        public static IQueryable<UserEntity> GetUsers([Service] UsersContext db)
        {
            return db.Users;
        }

        [NodeResolver]
        public static async Task<UserEntity?> GetUserById(
            Guid id,
            UserByIdDataLoader loader,
            CancellationToken cancellationToken
            )
        {
            return await loader.LoadAsync(id,cancellationToken);
        }

    }

}
