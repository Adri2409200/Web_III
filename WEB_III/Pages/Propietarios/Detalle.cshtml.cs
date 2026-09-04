using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Propietarios
{
    public class DetalleModel : PageModel
    {
        private readonly IPropietarioService _propietarioService;
        private readonly IMascotaService     _mascotaService;

        public Propietario Propietario { get; private set; } = null!;
        public IEnumerable<Mascota> Mascotas { get; private set; } = [];

        public DetalleModel(IPropietarioService propietarioService, IMascotaService mascotaService)
        {
            _propietarioService = propietarioService;
            _mascotaService     = mascotaService;
        }

        public IActionResult OnGet(int id)
        {
            var propietario = _propietarioService.ObtenerPorId(id);
            if (propietario is null) return NotFound();

            Propietario = propietario;
            Mascotas    = _mascotaService.ObtenerPorPropietario(id);
            return Page();
        }
    }
}
