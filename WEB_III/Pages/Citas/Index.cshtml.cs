using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Models.Enums;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Citas
{
    public class IndexModel : PageModel
    {
        private readonly ICitaService _service;

        public IEnumerable<Cita> Citas { get; private set; } = [];

        [BindProperty(SupportsGet = true)]
        public string? FiltroEstado { get; set; }

        [TempData]
        public string? MensajeExito { get; set; }

        public IndexModel(ICitaService service) => _service = service;

        public void OnGet()
        {
            var todas = _service.ObtenerTodosConDetalles();

            Citas = string.IsNullOrWhiteSpace(FiltroEstado)
                ? todas
                : Enum.TryParse<EstadoCita>(FiltroEstado, out var estado)
                    ? todas.Where(c => c.Estado == estado)
                    : todas;
        }
    }
}
