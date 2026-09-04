using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Citas
{
    public class DetalleModel : PageModel
    {
        private readonly ICitaService _service;

        public Cita Cita { get; private set; } = null!;

        public DetalleModel(ICitaService service) => _service = service;

        public IActionResult OnGet(int id)
        {
            var cita = _service.ObtenerPorIdConDetalles(id);
            if (cita is null) return NotFound();

            Cita = cita;
            return Page();
        }
    }
}
