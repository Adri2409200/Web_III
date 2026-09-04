using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB_III.Services.Interfaces;

namespace WEB_III.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPropietarioService _propietarioService;
        private readonly IMascotaService     _mascotaService;
        private readonly IVeterinarioService _veterinarioService;
        private readonly ICitaService        _citaService;

        public int TotalPropietarios { get; private set; }
        public int TotalMascotas     { get; private set; }
        public int TotalVeterinarios { get; private set; }
        public int TotalCitas        { get; private set; }
        public int CitasPendientes   { get; private set; }

        public IndexModel(
            IPropietarioService propietarioService,
            IMascotaService     mascotaService,
            IVeterinarioService veterinarioService,
            ICitaService        citaService)
        {
            _propietarioService = propietarioService;
            _mascotaService     = mascotaService;
            _veterinarioService = veterinarioService;
            _citaService        = citaService;
        }

        public void OnGet()
        {
            TotalPropietarios = _propietarioService.ObtenerTodos().Count();
            TotalMascotas     = _mascotaService.ObtenerTodos().Count();
            TotalVeterinarios = _veterinarioService.ObtenerTodos().Count();
            TotalCitas        = _citaService.ObtenerTodos().Count();
            CitasPendientes   = _citaService.ObtenerPorEstado(Models.Enums.EstadoCita.Pendiente).Count();
        }
    }
}
