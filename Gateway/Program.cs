using Gateway;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors().AddHeaderPropagation(c =>
{
    c.Headers.Add("GraphQL-Preflight");
    c.Headers.Add("Authorization");
});



builder.Services.AddHttpClient("Fusion").AddHeaderPropagation();

var gateway = builder.Services
    .AddFusionGatewayServer()
    .ConfigureFromFile("./gateway.fgp");

gateway.CoreBuilder.AddErrorFilter<ErrorFilter>();
gateway.CoreBuilder.AddApolloTracing();

var app = builder.Build();

app.UseWebSockets();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHeaderPropagation();
app.MapGraphQL();

app.RunWithGraphQLCommands(args);
