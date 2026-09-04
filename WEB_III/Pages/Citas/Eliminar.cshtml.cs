using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Citas
{
    public class EliminarModel : PageModel
    {
        private readonly ICitaService _service;

        public EliminarModel(ICitaService service) => _service = service;

        public IActionResult OnPost(int id)
        {
            var cita = _service.ObtenerPorId(id);
            if (cita is null) return NotFound();

            _service.Eliminar(id);
            TempData["MensajeExito"] = $"Cita #{id} eliminada correctamente.";
            return RedirectToPage("Index");
        }
    }
}
