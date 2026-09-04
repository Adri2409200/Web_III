using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Veterinarios
{
    public class EliminarModel : PageModel
    {
        private readonly IVeterinarioService _service;

        public EliminarModel(IVeterinarioService service) => _service = service;

        public IActionResult OnPost(int id)
        {
            var veterinario = _service.ObtenerPorId(id);
            if (veterinario is null) return NotFound();

            _service.Eliminar(id);
            TempData["MensajeExito"] = $"Veterinario \"{veterinario.NombreCompleto}\" eliminado correctamente.";
            return RedirectToPage("Index");
        }
    }
}
