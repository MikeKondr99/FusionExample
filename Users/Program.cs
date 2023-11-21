using Microsoft.EntityFrameworkCore;
using Users;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Database
services.AddDbContext<UsersContext>(
    options => options.UseSqlite("Data Source=users.db")
    );
// Hotchocolate
services
    .AddGraphQLServer()
    .AddAutoTypes()
    .RegisterDbContext<UsersContext>()
    .AddFiltering()
    .AddSorting()
    ;


var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);

