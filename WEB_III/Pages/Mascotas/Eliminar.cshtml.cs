using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Mascotas
{
    public class EliminarModel : PageModel
    {
        private readonly IMascotaService _service;

        public EliminarModel(IMascotaService service) => _service = service;

        public IActionResult OnPost(int id)
        {
            var mascota = _service.ObtenerPorId(id);
            if (mascota is null) return NotFound();

            _service.Eliminar(id);
            TempData["MensajeExito"] = $"Mascota \"{mascota.Nombre}\" eliminada correctamente.";
            return RedirectToPage("Index");
        }
    }
}
