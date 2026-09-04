using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Veterinarios
{
    public class EditarModel : PageModel
    {
        private readonly IVeterinarioService _service;

        [BindProperty]
        public Veterinario Veterinario { get; set; } = new();

        public EditarModel(IVeterinarioService service) => _service = service;

        public IActionResult OnGet(int id)
        {
            var veterinario = _service.ObtenerPorId(id);
            if (veterinario is null) return NotFound();

            Veterinario = veterinario;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _service.Actualizar(Veterinario);
            TempData["MensajeExito"] = $"Veterinario \"{Veterinario.NombreCompleto}\" actualizado correctamente.";
            return RedirectToPage("Index");
        }
    }
}
