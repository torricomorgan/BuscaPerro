using BuscaPerro.Domain.Interfaces.Services;
using Domain.BuscaPerro.Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuscaPerroApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService cuentaService;

        public CuentaController(ICuentaService cuentaService)
        {
            this.cuentaService = cuentaService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CrearCuenta([FromBody] CuentaEntity parCrearCuenta)
        {
            return Ok(1);
        }
    }
}
