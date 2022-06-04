using BuscaPerro.Domain.Autentificacion.DTO;
using BuscaPerro.Domain.Autentificacion.Interfaces;
using BuscaPerro.Domain.Autentificacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuscaPerroApi.Controllers.Autentificacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AutentificacionController : ControllerBase
    {
        private readonly IAutorizacionService autorizacionService;

        public AutentificacionController(IAutorizacionService autorizacionService)
        {
            this.autorizacionService = autorizacionService;
        }

        [HttpPost]
        public async Task<ActionResult<AutorizacionDTO>> Login([FromBody] ParLogIn parLogIn)
        {
            return Ok(await this.autorizacionService.IniciarSesion(parLogIn));
        }
    }
}
