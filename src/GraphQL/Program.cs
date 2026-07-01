using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddGraphQL().AddTypes();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
