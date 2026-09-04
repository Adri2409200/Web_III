using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Propietarios
{
    public class EditarModel : PageModel
    {
        private readonly IPropietarioService _service;

        [BindProperty]
        public Propietario Propietario { get; set; } = new();

        public EditarModel(IPropietarioService service) => _service = service;

        public IActionResult OnGet(int id)
        {
            var propietario = _service.ObtenerPorId(id);
            if (propietario is null) return NotFound();

            Propietario = propietario;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _service.Actualizar(Propietario);
            TempData["MensajeExito"] = $"Propietario \"{Propietario.NombreCompleto}\" actualizado correctamente.";
            return RedirectToPage("Index");
        }
    }
}
