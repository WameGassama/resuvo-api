using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.AddGraphQL()
    .AddAuthorization()
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

app.UseAuthentication();
app.UseAuthorization();


app.MapGraphQLHttp().RequireAuthorization();
app.MapNitroApp();

app.RunWithGraphQLCommands(args);
