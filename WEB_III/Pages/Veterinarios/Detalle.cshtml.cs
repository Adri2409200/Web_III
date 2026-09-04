using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Veterinarios
{
    public class DetalleModel : PageModel
    {
        private readonly IVeterinarioService _veterinarioService;
        private readonly ICitaService        _citaService;

        public Veterinario Veterinario { get; private set; } = null!;
        public IEnumerable<Cita> Citas { get; private set; } = [];

        public DetalleModel(IVeterinarioService veterinarioService, ICitaService citaService)
        {
            _veterinarioService = veterinarioService;
            _citaService        = citaService;
        }

        public IActionResult OnGet(int id)
        {
            var veterinario = _veterinarioService.ObtenerPorId(id);
            if (veterinario is null) return NotFound();

            Veterinario = veterinario;
            Citas       = _citaService.ObtenerPorVeterinario(id);
            return Page();
        }
    }
}
