using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Veterinarios
{
    public class CrearModel : PageModel
    {
        private readonly IVeterinarioService _service;

        [BindProperty]
        public Veterinario Veterinario { get; set; } = new();

        public CrearModel(IVeterinarioService service) => _service = service;

        public IActionResult OnGet() => Page();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _service.Crear(Veterinario);
            TempData["MensajeExito"] = $"Veterinario \"{Veterinario.NombreCompleto}\" creado correctamente.";
            return RedirectToPage("Index");
        }
    }
}
