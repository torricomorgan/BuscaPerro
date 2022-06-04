using BuscaPerro.Domain.Mascota.DTO;
using BuscaPerro.Domain.Mascota.Entidad;
using BuscaPerro.Domain.Mascota.Interfaces.Services;
using BuscaPerro.Domain.Mascota.Models;
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
        public async Task<ActionResult<int>> RegistrarMascota([FromBody] ParRegistrarMascota parRegistrarMascota)
        {
            return Ok(await this.mascotaService.RegistrarMascota(parRegistrarMascota));
        }
        [HttpGet]
        public async Task<ActionResult<MascotaDTO>> RetornarPerfilMascota(int idMascota)
        {
            return Ok(await this.mascotaService.PerfilMascota(idMascota));
        }
        [HttpGet]
        public async Task<ActionResult<RazaEntity>> ListarMascotasPorCuenta(int idCuenta)
        {
            return Ok(await this.mascotaService.ListarMascotaPorCuenta(idCuenta));
        }
        [HttpGet]
        public async Task<ActionResult<RazaEntity>> RetornarRazas(int idEspecia)
        {
            return Ok(await this.mascotaService.RetornarRazas(idEspecia));
        }
    }
}
