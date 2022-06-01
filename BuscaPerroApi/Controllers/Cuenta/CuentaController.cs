using BuscaPerro.Domain.Cuenta.Entidad;
using BuscaPerro.Domain.Cuenta.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuscaPerroApi.Controllers.Cuenta
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
