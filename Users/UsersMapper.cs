﻿using Riok.Mapperly.Abstractions;
using Users.Inputs;

namespace Users
{
    [Mapper]
    public static partial class UsersMapper
    {
        public static void UpdateUser(UpdateUserInput source,User target)
        {
            if (source.Name.HasValue) target.Name = source.Name.Value;
            if (source.Sex.HasValue) target.Sex = source.Sex.Value;
        }

        public static partial User CreateUser(CreateUserInput source);

    }
}
