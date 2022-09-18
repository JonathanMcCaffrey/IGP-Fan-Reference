using Microsoft.EntityFrameworkCore;
using Server;
using Server.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapEntityWeaponEndpoints();

app.MapEntityEndpoints();

app.MapGraphQL();


app.Run();