using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Propietarios
{
    public class EliminarModel : PageModel
    {
        private readonly IPropietarioService _service;

        public EliminarModel(IPropietarioService service) => _service = service;

        public IActionResult OnPost(int id)
        {
            var propietario = _service.ObtenerPorId(id);
            if (propietario is null) return NotFound();

            _service.Eliminar(id);
            TempData["MensajeExito"] = $"Propietario \"{propietario.NombreCompleto}\" eliminado correctamente.";
            return RedirectToPage("Index");
        }
    }
}
