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
        public async Task<ActionResult<IEnumerable<Proveedor_vacunaEntity>>> ListarProveedores()
        {
            return Ok(await this.vacunacionService.ListarProveedoresVacunas());
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacunaDTO>>> ListarVacunas()
        {
            return Ok(await this.vacunacionService.ListarVacunas());
        }
    }
}
