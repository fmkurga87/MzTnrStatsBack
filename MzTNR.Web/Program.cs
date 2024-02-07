using Microsoft.EntityFrameworkCore;
using MzTNR.Contracts.Ciudades;
using MzTNR.Contracts.Equipos;
using MzTNR.Contracts.Provincias;
using MzTNR.Services.Ciudades;
using MzTNR.Services.Equipos;
using MzTNR.Services.Profiles;
using MzTNR.Services.Provincias;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddDbContext<MzTNR.Data.Data.ApplicationDbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddScoped<IServicioProvincias, ServicioProvincias>();
builder.Services.AddScoped<IServicioCiudades, ServicioCiudades>();
builder.Services.AddScoped<IServicioEquipos, ServicioEquipos>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
