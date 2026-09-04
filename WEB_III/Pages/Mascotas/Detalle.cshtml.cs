using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Mascotas
{
    public class DetalleModel : PageModel
    {
        private readonly IMascotaService _mascotaService;
        private readonly ICitaService    _citaService;

        public Mascota Mascota { get; private set; } = null!;
        public IEnumerable<Cita> Citas { get; private set; } = [];

        public DetalleModel(IMascotaService mascotaService, ICitaService citaService)
        {
            _mascotaService = mascotaService;
            _citaService    = citaService;
        }

        public IActionResult OnGet(int id)
        {
            var mascota = _mascotaService.ObtenerPorId(id);
            if (mascota is null) return NotFound();

            Mascota = mascota;
            Citas   = _citaService.ObtenerPorMascota(id);
            return Page();
        }
    }
}
