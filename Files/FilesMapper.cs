using Files;
using Files.Inputs;
using Riok.Mapperly.Abstractions;

namespace Files
{
    [Mapper]
    public static partial class FilesMapper
    {
        public static void UpdateFile(UpdateFileInput source,File target)
        {
            if (source.Name.HasValue) target.Name = source.Name.Value;
        }

        public static partial File CreateFile(CreateFileInput source);

        public static byte[] FileToBytes(IFile file)
        {
            var stream = file.OpenReadStream();
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

    }
}
