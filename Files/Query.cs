using Files;

namespace Files;

[QueryType]
public static class Query
{
    public static IQueryable<FileEntity> GetFiles(FilesContext db)
    {
        return db.Files;
    }

    [NodeResolver]
    public static async Task<FileEntity?> GetFileById(
        Guid id,
        FileByIdDataLoader loader,
        CancellationToken cancellationToken)
    {
        return await loader.LoadAsync(id,cancellationToken);
    }
}
