using Microsoft.EntityFrameworkCore;
using WorkshopMng.Application.Interfaces;
using WorkshopMng.Application.Services;
using WorkshopMng.Domain.Domains;
using WorkshopMng.Persistence;
using WorkshopMng.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WorkshopContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IAtaService<Ata>, AtaService>();
builder.Services.AddScoped<IColaboradorService<Colaborador>, ColaboradorService>();
builder.Services.AddScoped<IWorkshopService<WorkshopMng.Domain.Domains.Workshop>, WorkshopService>();

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

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<WorkshopContext>();
    context.Database.Migrate();
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Ocorreu um erro durante a migration.");
}

app.Run();
