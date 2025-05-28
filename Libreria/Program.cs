using Libreria.Components;
using Libreria.Data;
using Libreria.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Razor Components (equivalente moderno a Blazor Server)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Conexión a la base de datos
builder.Services.AddDbContext<BDLibreriaDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDLibreriaDBContext")));

// Inyección de dependencias para repositorios
builder.Services.AddScoped<IRepositorioClientes, RepositorioClientes>();
builder.Services.AddScoped<IRepositorioLibros, RepositorioLibros>();
builder.Services.AddScoped<IRepositorioVentas, RepositorioVentas>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

// Aquí se renderiza la app Blazor moderna (NO se usa _Host.cshtml)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
