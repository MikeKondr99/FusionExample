using Files.Inputs;
using HotChocolate.Language;
using System.Reflection;

namespace Files
{

    [MutationType]
    public static class Mutation
    {
        public static File CreateFile(CreateFileInput input, FilesContext context)
        {
            var user = FilesMapper.CreateFile(input);
            context.Files.Add(user);
            context.SaveChanges();
            return user;
        }

        public static File UpdateFile(UpdateFileInput input, FilesContext context)
        {

            var user = context.Files.Find(input.Id);
            if (user is null) throw new KeyNotFoundException();
            FilesMapper.UpdateFile(input, user);
            context.SaveChanges();

            return user;
        }

        public static File DeleteFile(Guid id, FilesContext context)
        {
            var user = context.Files.Find(id);
            if (user is null) throw new KeyNotFoundException();
            context.Files.Remove(user);
            context.SaveChanges();
            return user;
        }
    }

    namespace Inputs
    {
        public class CreateFileInput
        {
            public required UpperCaseString Sign { get; set; }
            
            public required Ogrn Ogrn { get; set; }

            public Guid UserId { get; set; }
            public required string Name { get; set; }

            [GraphQLType<NonNullType<UploadType>>]
            public required IFile Blob { get; set; }
        }

        public class UpdateFileInput
        {
            public Guid Id { get; set; }

            [DefaultValue("")]
            public Optional<string> Name { get; set; }

        }

    }
}
