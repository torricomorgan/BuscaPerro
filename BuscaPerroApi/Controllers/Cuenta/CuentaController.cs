using BuscaPerro.Domain.Cuenta.DTO;
using BuscaPerro.Domain.Cuenta.Entidad;
using BuscaPerro.Domain.Cuenta.Interfaces.Services;
using BuscaPerro.Domain.Cuenta.Models;
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
        public async Task<ActionResult<bool>> RegistrarCuenta([FromBody] ParRegistrarCuenta parRegistrarCuenta)
        {
            return Ok(await this.cuentaService.RegistrarCuenta(parRegistrarCuenta));
        }

        [HttpGet]
        public async Task<ActionResult<CuentaDTO>> RetornarPerfilCuenta(int idCuenta)
        {
            return Ok(await this.cuentaService.RetornarPerfilCuenta(idCuenta));
        }
    }
}
