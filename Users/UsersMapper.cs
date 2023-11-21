using Riok.Mapperly.Abstractions;
using Users.Inputs;

namespace Users
{
    [Mapper]
    public static partial class UsersMapper
    {
        public static void UpdateUser(UpdateUserInput source,UserEntity target)
        {
            if (source.Name.HasValue) target.Name = source.Name.Value;
            if (source.Sex.HasValue) target.Sex = source.Sex.Value;
        }

        public static partial UserEntity CreateUser(CreateUserInput source);

    }
}
