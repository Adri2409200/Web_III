using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Propietarios
{
    public class IndexModel : PageModel
    {
        private readonly IPropietarioService _service;

        public IEnumerable<Propietario> Propietarios { get; private set; } = [];

        [BindProperty(SupportsGet = true)]
        public string? Busqueda { get; set; }

        [TempData]
        public string? MensajeExito { get; set; }

        public IndexModel(IPropietarioService service) => _service = service;

        public void OnGet()
        {
            Propietarios = string.IsNullOrWhiteSpace(Busqueda)
                ? _service.ObtenerTodos()
                : _service.Buscar(Busqueda);
        }
    }
}
