using Files;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Files;

[QueryType]
public static class Query
{
    public static IQueryable<File> GetFiles(FilesContext db)
    {
        return db.Files;
    }

    [NodeResolver]
    public static async Task<File?> GetFileById(
        Guid id,
        FileByIdDataLoader loader,
        CancellationToken cancellationToken)
    {
        return await loader.LoadAsync(id,cancellationToken);
    }

}

[ExtendObjectType<File>]
public static class ExpandFile
{

    [DataLoader]
    public static async Task<IReadOnlyDictionary<Guid, File>> GetFileByIdAsync(
        IReadOnlyList<Guid> ids,
        FilesContext db,
        CancellationToken cancellationToken)
    {
        return await db.Files.Where(f => ids.Contains(f.Id)).ToDictionaryAsync(f => f.Id, cancellationToken);
    }

    public static async Task<User> GetUserAsync(
       [Parent] File file,
       CancellationToken cancellationToken)
       => new User() { Id = file.UserId };
}

public class User
{
    public Guid Id { get; set; }
}



