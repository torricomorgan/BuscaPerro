using BuscaPerro.Domain.Enfermedad.DTO;
using BuscaPerro.Domain.Enfermedad.Entidad;
using BuscaPerro.Domain.Enfermedad.Interfaces.Services;
using BuscaPerro.Domain.Enfermedad.Models;
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
        public async Task<ActionResult<int>> RegistrarEnfermedad([FromBody] ParRegistrarEnfermedad parRegistrarEnfermedad)
        {
            return Ok(await this.enfermedadService.RegistrarEnfermedad(parRegistrarEnfermedad));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnfermedadEntity>>> ListarEnfermedades()
        {
            return Ok(await this.enfermedadService.ListarEnfermedades());
        }
        [HttpPost]
        public async Task<ActionResult<int>> RegistrarEnfermedadMascota([FromBody] ParRegistrarHistoricoEnfermedad parRegistrarHistoricoEnfermedad)
        {
            return Ok(await this.enfermedadService.RegistrarEnfermedadHistorico(parRegistrarHistoricoEnfermedad));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoEnfermedadDTO>>> ListarEnfermedadesMascota(int idMascota)
        {
            return Ok(await this.enfermedadService.ListarHistoricoEnfermedad(idMascota));
        }
    }
}
