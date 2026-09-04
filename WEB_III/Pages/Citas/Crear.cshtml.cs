using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Citas
{
    public class CrearModel : PageModel
    {
        private readonly ICitaService        _citaService;
        private readonly IMascotaService     _mascotaService;
        private readonly IVeterinarioService _veterinarioService;

        [BindProperty]
        public Cita Cita { get; set; } = new();

        public SelectList MascotasSelect     { get; private set; } = null!;
        public SelectList VeterinariosSelect { get; private set; } = null!;

        public CrearModel(
            ICitaService        citaService,
            IMascotaService     mascotaService,
            IVeterinarioService veterinarioService)
        {
            _citaService        = citaService;
            _mascotaService     = mascotaService;
            _veterinarioService = veterinarioService;
        }

        public IActionResult OnGet()
        {
            CargarSelects();
            // Fecha por defecto: mañana a las 9:00
            Cita.FechaHoraAtencion = DateTime.Today.AddDays(1).AddHours(9);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CargarSelects();
                return Page();
            }

            _citaService.Crear(Cita);
            TempData["MensajeExito"] = "Cita agendada correctamente.";
            return RedirectToPage("Index");
        }

        private void CargarSelects()
        {
            MascotasSelect = new SelectList(
                _mascotaService.ObtenerActivas(),
                nameof(Mascota.Id),
                nameof(Mascota.Nombre));

            VeterinariosSelect = new SelectList(
                _veterinarioService.ObtenerActivos(),
                nameof(Veterinario.Id),
                nameof(Veterinario.NombreCompleto));
        }
    }
}
