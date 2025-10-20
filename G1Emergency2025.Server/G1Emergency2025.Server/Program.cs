using G1Emergency2025.BD.Datos;
using G1Emergency2025.BD.Datos.Entity;
using G1Emergency2025.Repositorio.IRepositorios;
using G1Emergency2025.Repositorio.Repositorios;
using G1Emergency2025.Server.Client.Pages;
using G1Emergency2025.Server.Components;
using G1Emergency2025.Servicio.ServiciosHttp;
using G1Emergency2025.Shared.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7150/")
});
// Add services to the container.
#region Construccion
builder.Services.AddScoped<IHttpServicio, HttpServicio>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "G1Emergency2025 API",
        Version = "v1",
        Description = "API de Emergency",
    });
});
var StrConn = builder.Configuration.GetConnectionString("ConSql")
                                 ?? throw new InvalidOperationException(
                                    "El string de conexion no existe.");
builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(StrConn));


//CONEXION BLAZOR CON API




//REPOSITORIOS

//JOAQUIN
builder.Services.AddScoped<ICausaRepositorio, CausaRepositorio>();
builder.Services.AddScoped<IDiagPresuntivoRepositorio, DiagPresuntivoRepositorio>();
builder.Services.AddScoped<ILugarHechoRepositorio, LugarHechoRepositorio>();
builder.Services.AddScoped<ITipoEstadoRepositorio, TipoEstadoRepositorio>();
builder.Services.AddScoped<IMovilRepositorio, MovilRepositorio>();
builder.Services.AddScoped<IEventoRepositorio, EventoRepositorio>();

//ZOE
builder.Services.AddScoped<IHistoricoRepositorio, HistoricoRepositorio>();
builder.Services.AddScoped<ITipoMovilRepositorio, TipoMovilRepositorio>();
builder.Services.AddScoped<ITipoTripulanteRepositorio, TipoTripulanteRepositorio>();
builder.Services.AddScoped<ITripulacionActualRepositorio, TripulacionActualRepositorio>();
builder.Services.AddScoped<ITripulanteRepositorio, TripulanteRepositorio>();

//EMILSE

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();
builder.Services.AddScoped<IRolRepositorio, RolRepositorio>();
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();



builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.

#region Configuracion

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Modelado2025-1 API v1");
        c.RoutePrefix = "swagger"; // Swagger en /swagger
    });
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(G1Emergency2025.Server.Client._Imports).Assembly);

app.MapControllers();
#endregion+

app.Run();
