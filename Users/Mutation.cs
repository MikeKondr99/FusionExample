using Users.Inputs;

namespace Users
{
    [MutationType]
    public static class Mutation
    {

        public static UserEntity CreateUser(CreateUserInput input,UsersContext context)
        {
            var user = UsersMapper.CreateUser(input);
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public static UserEntity UpdateUser(UpdateUserInput input,UsersContext context)
        {
            var user = context.Users.Find(input.Id);
            if (user is null) throw new KeyNotFoundException();
            UsersMapper.UpdateUser(input, user);
            context.SaveChanges();
            return user;
        }

        public static UserEntity DeleteUser(Guid id, UsersContext context)
        {
            var user = context.Users.Find(id);
            if (user is null) throw new KeyNotFoundException();
            context.Users.Remove(user);
            context.SaveChanges();
            return user;
        }
    }

    namespace Inputs
    {
        public class CreateUserInput
        {
            public required string Name { get; set; }
            public Sex Sex { get; set; }
        }

        public class UpdateUserInput
        {
            public Guid Id { get; set; }

            [DefaultValue("")]
            public Optional<string> Name { get; set; }


            [DefaultValue(Users.Sex.Male)]
            public Optional<Sex> Sex { get; set; }
        }

    }
}
