using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.AddGraphQL()
       .AddTypes()
       .AddQueryConventions()
       .AddMutationConventions(applyToAllMutations: true);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseCors(builder =>
{
       builder.AllowAnyOrigin();
       builder.AllowAnyHeader();
       builder.AllowAnyMethod();
});

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
