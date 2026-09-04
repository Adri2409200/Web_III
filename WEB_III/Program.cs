using WEB_III.Repositories.Implementations;
using WEB_III.Repositories.Interfaces;
using WEB_III.Services.Implementations;
using WEB_III.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// ── Razor Pages ────────────────────────────────────────────────────────────
builder.Services.AddRazorPages();

// ── Repositorios (Singleton para persistir datos en memoria) ───────────────
builder.Services.AddSingleton<IPropietarioRepository, PropietarioRepository>();
builder.Services.AddSingleton<IMascotaRepository,     MascotaRepository>();
builder.Services.AddSingleton<IVeterinarioRepository, VeterinarioRepository>();
builder.Services.AddSingleton<ICitaRepository,        CitaRepository>();

// ── Servicios ──────────────────────────────────────────────────────────────
builder.Services.AddScoped<IPropietarioService, PropietarioService>();
builder.Services.AddScoped<IMascotaService,     MascotaService>();
builder.Services.AddScoped<IVeterinarioService, VeterinarioService>();
builder.Services.AddScoped<ICitaService,        CitaService>();

var app = builder.Build();

// ── Pipeline ───────────────────────────────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
