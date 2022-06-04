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
        [HttpPost]
        public async Task<ActionResult<int>> RegistrarPesoMascota([FromBody] ParRegistrarPeso parRegistrarPeso)
        {
            return Ok(await this.mascotaService.RegistrarHistorialPeso(parRegistrarPeso));
        }
        [HttpGet]
        public async Task<ActionResult<RazaEntity>> ListarPesosMascota(int idMascota)
        {
            return Ok(await this.mascotaService.ListarHistorialPesoPorMascota(idMascota));
        }
        [HttpGet]
        public async Task<ActionResult<RazaEntity>> RetornarEspecies()
        {
            return Ok(await this.mascotaService.RetornarEspecies());
        }
        [HttpPost]
        public async Task<ActionResult<int>> RegistrarRaza([FromBody] ParRegistrarRaza parRegistrarRaza)
        {
            return Ok(await this.mascotaService.RegistrarRazas(parRegistrarRaza));
        }
        [HttpGet]
        public async Task<ActionResult<RazaEntity>> RetornarRazas(int idEspecia)
        {
            return Ok(await this.mascotaService.RetornarRazas(idEspecia));
        }
    }
}
