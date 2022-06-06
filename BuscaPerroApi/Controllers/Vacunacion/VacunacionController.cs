using BuscaPerro.Domain.Vacunacion.DTO;
using BuscaPerro.Domain.Vacunacion.Entidad;
using BuscaPerro.Domain.Vacunacion.Interfaces.Services;
using BuscaPerro.Domain.Vacunacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuscaPerroApi.Controllers.Vacunacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VacunacionController : ControllerBase
    {
        private readonly IVacunacionService vacunacionService;

        public VacunacionController(IVacunacionService vacunacionService)
        {
            this.vacunacionService = vacunacionService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarVacuna([FromBody] ParRegistrarVacuna parRegistrarVacuna)
        {
            return Ok(await this.vacunacionService.RegistrarVacuna(parRegistrarVacuna));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacunaDTO>>> ListarVacunas()
        {
            return Ok(await this.vacunacionService.ListarVacunas());
        }
        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarVacunaMascota([FromBody] ParRegistrarVacunaCalendario parRegistrarVacuna)
        {
            return Ok(await this.vacunacionService.RegistrarVacunaACalendario(parRegistrarVacuna));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacunaCalendarioDTO>>> ListarVacunasMascota(int idMascota)
        {
            return Ok(await this.vacunacionService.ListarCalendarioVacunaPorMascota(idMascota));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacunaCalendarioDTO>>> ListarVacunasMascotaCuenta(int idCuenta)
        {
            return Ok(await this.vacunacionService.ListarCalendarioVacunasPorCuenta(idCuenta));
        }
        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarProveedores([FromBody] ParRegistrarProveedor parRegistrarProveedor)
        {
            return Ok(await this.vacunacionService.RegistrarProveedorVacuna(parRegistrarProveedor));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor_vacunaEntity>>> ListarProveedores()
        {
            return Ok(await this.vacunacionService.ListarProveedoresVacunas());
        }
    }
}
