using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Mascotas
{
    public class CrearModel : PageModel
    {
        private readonly IMascotaService     _mascotaService;
        private readonly IPropietarioService _propietarioService;

        [BindProperty]
        public Mascota Mascota { get; set; } = new();

        public SelectList PropietariosSelect { get; private set; } = null!;

        public CrearModel(IMascotaService mascotaService, IPropietarioService propietarioService)
        {
            _mascotaService     = mascotaService;
            _propietarioService = propietarioService;
        }

        public IActionResult OnGet()
        {
            CargarPropietarios();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CargarPropietarios();
                return Page();
            }

            _mascotaService.Crear(Mascota);
            TempData["MensajeExito"] = $"Mascota \"{Mascota.Nombre}\" creada correctamente.";
            return RedirectToPage("Index");
        }

        private void CargarPropietarios() =>
            PropietariosSelect = new SelectList(
                _propietarioService.ObtenerActivos(),
                nameof(Propietario.Id),
                nameof(Propietario.NombreCompleto));
    }
}
