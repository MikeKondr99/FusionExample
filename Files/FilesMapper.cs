using Files;
using Files.Inputs;
using Riok.Mapperly.Abstractions;

namespace Files
{
    [Mapper]
    public static partial class FilesMapper
    {
        public static void UpdateFile(UpdateFileInput source,FileEntity target)
        {
            if (source.Name.HasValue) target.Name = source.Name.Value;
        }

        public static partial FileEntity CreateFile(CreateFileInput source);

    }
}
