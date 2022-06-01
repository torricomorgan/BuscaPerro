using BuscaPerro.Domain.Mascota.Entidad;
using BuscaPerro.Domain.Mascota.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuscaPerroApi.Controllers.Mascota
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaService mascotaService;

        public MascotaController(IMascotaService mascotaService)
        {
            this.mascotaService = mascotaService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> RegistrarMascota([FromBody] MascotaEntity parRegistrarMascota)
        {
            return Ok(1);
        }
    }
}
