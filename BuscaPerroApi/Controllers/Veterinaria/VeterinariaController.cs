using BuscaPerro.Domain.Veterinaria.DTO;
using BuscaPerro.Domain.Veterinaria.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuscaPerroApi.Controllers.Veterinaria
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VeterinariaController : ControllerBase
    {
        private readonly IVeterinariaService veterinariaService;

        public VeterinariaController(IVeterinariaService veterinariaService)
        {
            this.veterinariaService = veterinariaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UbicacionVeterinariasDTO>>> ListarVeterinariasCercanas()
        {
            return Ok(await this.veterinariaService.ListarVeterinariasCercanas());
        }
    }
}
