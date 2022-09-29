using Microsoft.EntityFrameworkCore;
using Server;
using Server.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddType<Entity>()
    .AddType<EntityWeapon>();

var connectionString = builder.Configuration["ConnectionStrings:IGP"];

builder.Services.AddDbContext<JonathanMccaffreyContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapGraphQL();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();