using Files.Inputs;

namespace Files
{

    [MutationType]
    public static class Mutation
    {
        public static FileEntity CreateFile(CreateFileInput input, FilesContext context)
        {
            var user = FilesMapper.CreateFile(input);
            context.Files.Add(user);
            context.SaveChanges();
            return user;
        }

        public static FileEntity UpdateFile(UpdateFileInput input, FilesContext context)
        {
            var user = context.Files.Find(input.Id);
            if (user is null) throw new KeyNotFoundException();
            FilesMapper.UpdateFile(input, user);
            context.SaveChanges();
            return user;
        }

        public static FileEntity DeleteFile(Guid id, FilesContext context)
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
            public Guid UserId { get; set; }
            public required string Name { get; set; }
        }

        public class UpdateFileInput
        {
            public Guid Id { get; set; }

            [DefaultValue("")]
            public Optional<string> Name { get; set; }

        }

    }
}
