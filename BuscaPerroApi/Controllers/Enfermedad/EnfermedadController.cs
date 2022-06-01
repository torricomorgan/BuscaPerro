using BuscaPerro.Domain.Enfermedad.Entidad;
using BuscaPerro.Domain.Enfermedad.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuscaPerroApi.Controllers.Enfermedad
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnfermedadController : ControllerBase
    {
        private readonly IEnfermedadService enfermedadService;

        public EnfermedadController(IEnfermedadService enfermedadService)
        {
            this.enfermedadService = enfermedadService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> RegistrarEnfermedad([FromBody] EnfermedadEntity parRegistrarEnfermedad)
        {
            return Ok(1);
        }
    }
}
