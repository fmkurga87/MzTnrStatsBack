using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MzTNR.Contracts.Ciudades;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Equipos;
using MzTNR.Contracts.Partidos;
using MzTNR.Contracts.Provincias;
using MzTNR.Contracts.Torneos;
using MzTNR.Services.Ciudades;
using MzTNR.Services.Equipos;
using MzTNR.Services.Extensiones;
using MzTNR.Services.Partidos;
using MzTNR.Services.Profiles;
using MzTNR.Services.Provincias;
using MzTNR.Services.Torneos;

//CORS
var MyAllowSpecificationOrigins = "_myAllowSpecificationOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddDbContext<MzTNR.Data.Data.ApplicationDbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddScoped<IServicioProvincias, ServicioProvincias>();
builder.Services.AddScoped<IServicioCiudades, ServicioCiudades>();
builder.Services.AddScoped<IServicioEquipos, ServicioEquipos>();
builder.Services.AddScoped<IServicioPartidos, ServicioPartidos>();
builder.Services.AddScoped<IServicioTorneos, ServicioTorneos>();

builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificationOrigins,
    policy => policy.AllowAnyHeader()
        .AllowAnyMethod().AllowAnyOrigin());
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Configure(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors(MyAllowSpecificationOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

void Configure(WebApplication host)
{
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<MzTNR.Data.Data.ApplicationDbContext>();
        var mapper = services.GetRequiredService<IMapper>();
        
        // if (dbContext.Database.IsSqlServer())
        // {
        //     dbContext.Database.Migrate();
        // }

        // var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        // var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
        // AppDbContextSeed.SeedData(userManager, roleManager);
        DataSeed dataSeed = new DataSeed(dbContext, mapper){};
        dataSeed.Seeding();
    }
    catch (Exception ex)
    {
        //Log some error
        throw;
    }
}