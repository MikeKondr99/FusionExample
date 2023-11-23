using Files;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Database
services.AddDbContext<FilesContext>(
    options => options.UseSqlite("Data Source=files.db")
    );
// Hotchocolate
services
    .AddGraphQLServer()
    .AddAutoTypes()
    .AddUploadType()
    .RegisterDbContext<FilesContext>()
    .AddFiltering()
    .AddSorting()
    ;

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
