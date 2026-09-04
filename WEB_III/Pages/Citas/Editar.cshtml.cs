using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Citas
{
    public class EditarModel : PageModel
    {
        private readonly ICitaService        _citaService;
        private readonly IMascotaService     _mascotaService;
        private readonly IVeterinarioService _veterinarioService;

        [BindProperty]
        public Cita Cita { get; set; } = new();

        public SelectList MascotasSelect     { get; private set; } = null!;
        public SelectList VeterinariosSelect { get; private set; } = null!;

        public EditarModel(
            ICitaService        citaService,
            IMascotaService     mascotaService,
            IVeterinarioService veterinarioService)
        {
            _citaService        = citaService;
            _mascotaService     = mascotaService;
            _veterinarioService = veterinarioService;
        }

        public IActionResult OnGet(int id)
        {
            var cita = _citaService.ObtenerPorId(id);
            if (cita is null) return NotFound();

            Cita = cita;
            CargarSelects();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CargarSelects();
                return Page();
            }

            _citaService.Actualizar(Cita);
            TempData["MensajeExito"] = "Cita actualizada correctamente.";
            return RedirectToPage("Index");
        }

        private void CargarSelects()
        {
            MascotasSelect = new SelectList(
                _mascotaService.ObtenerActivas(),
                nameof(Mascota.Id),
                nameof(Mascota.Nombre),
                Cita.MascotaId);

            VeterinariosSelect = new SelectList(
                _veterinarioService.ObtenerActivos(),
                nameof(Veterinario.Id),
                nameof(Veterinario.NombreCompleto),
                Cita.VeterinarioId);
        }
    }
}
