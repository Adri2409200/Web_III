using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Models;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages.Propietarios
{
    public class CrearModel : PageModel
    {
        private readonly IPropietarioService _service;

        [BindProperty]
        public Propietario Propietario { get; set; } = new();

        public CrearModel(IPropietarioService service) => _service = service;

        public IActionResult OnGet() => Page();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _service.Crear(Propietario);
            TempData["MensajeExito"] = $"Propietario \"{Propietario.NombreCompleto}\" creado correctamente.";
            return RedirectToPage("Index");
        }
    }
}
