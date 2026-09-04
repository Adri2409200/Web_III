using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Mascotas
{
    public class IndexModel : PageModel
    {
        private readonly IMascotaService _service;

        public IEnumerable<Mascota> Mascotas { get; private set; } = [];

        [BindProperty(SupportsGet = true)]
        public string? Busqueda { get; set; }

        [TempData]
        public string? MensajeExito { get; set; }

        public IndexModel(IMascotaService service) => _service = service;

        public void OnGet()
        {
            var todas = _service.ObtenerTodos();

            Mascotas = string.IsNullOrWhiteSpace(Busqueda)
                ? todas
                : todas.Where(m =>
                    m.Nombre.Contains(Busqueda, StringComparison.OrdinalIgnoreCase) ||
                    m.Especie.Contains(Busqueda, StringComparison.OrdinalIgnoreCase) ||
                    m.Raza.Contains(Busqueda, StringComparison.OrdinalIgnoreCase));
        }
    }
}
