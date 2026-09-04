using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Veterinarios
{
    public class IndexModel : PageModel
    {
        private readonly IVeterinarioService _service;

        public IEnumerable<Veterinario> Veterinarios { get; private set; } = [];

        [BindProperty(SupportsGet = true)]
        public string? Busqueda { get; set; }

        [TempData]
        public string? MensajeExito { get; set; }

        public IndexModel(IVeterinarioService service) => _service = service;

        public void OnGet()
        {
            var todos = _service.ObtenerTodos();

            Veterinarios = string.IsNullOrWhiteSpace(Busqueda)
                ? todos
                : todos.Where(v =>
                    v.Nombre.Contains(Busqueda, StringComparison.OrdinalIgnoreCase)      ||
                    v.Apellido.Contains(Busqueda, StringComparison.OrdinalIgnoreCase)    ||
                    v.Especialidad.Contains(Busqueda, StringComparison.OrdinalIgnoreCase));
        }
    }
}
