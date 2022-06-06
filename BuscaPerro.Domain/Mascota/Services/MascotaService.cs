using BuscaPerro.Base.Generico;
using BuscaPerro.Domain.Interfaz.Mascota.Repository;
using BuscaPerro.Domain.Mascota.DTO;
using BuscaPerro.Domain.Mascota.Entidad;
using BuscaPerro.Domain.Mascota.Interfaces.Services;
using BuscaPerro.Domain.Mascota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace BuscaPerro.Domain.Mascota.Services
{
    public class MascotaService : IMascotaService
    {
        #region Instanciar repositorios
        private IMascotaRepository mascotaRepository;
        private IRazaRepository razaRepository;
        private IHistorial_pesoRepository historial_pesoRepository;
        private IEspecieRepository especieRepository;

        public MascotaService(IMascotaRepository mascotaRepository, 
            IRazaRepository razaRepository,
            IHistorial_pesoRepository historial_PesoRepository,
            IEspecieRepository especieRepository)
        {
            this.mascotaRepository = mascotaRepository;
            this.razaRepository = razaRepository;
            this.historial_pesoRepository = historial_PesoRepository;
            this.especieRepository = especieRepository;
        }
        #endregion

        public async Task<bool> RegistrarMascota(ParRegistrarMascota parRegistrarMascota)
        {
            #region Variables
            bool result = false;
            var mascota = new MascotaEntity();
            #endregion

            try
            {
                #region Transaccion
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    mascota = Metodos.PropertyCopier<MascotaEntity>.Convert(parRegistrarMascota);

                    await this.mascotaRepository.Insert(mascota);

                    scope.Complete();
                    result = true;
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<MascotaDTO> PerfilMascota(int idMascota)
        {
            #region Variables
            IEnumerable<MascotaDTO> mascotas = Enumerable.Empty<MascotaDTO>();
            var mascota = new MascotaDTO();
            #endregion

            try
            {
                mascotas = await this.mascotaRepository.ObtenerPerfilMascota(idMascota);
                if(mascotas.Any())
                    mascota = mascotas.First();
            }
            catch (Exception ex)
            {

            }
            return mascota;
        }
        public async Task<UbicacionMascotaDTO> RastrearMascota(int idMascota)
        {
            #region Variables
            var mascotaUbicacion = new UbicacionMascotaDTO();
            var ubicacion = new Nearest();
            HttpClient client = new HttpClient();
            string json = String.Empty;
            #endregion

            try
            {
                json = await client.GetStringAsync("https://api.3geonames.org/randomland.BO.json");
                var aux = JsonSerializer.Deserialize<Rootobject>(json);
                if (aux != null)
                    ubicacion = aux.nearest;
                mascotaUbicacion = new UbicacionMascotaDTO() {
                    latitud = ubicacion.latt,
                    longitud = ubicacion.longt,
                    ciudad = ubicacion.city,
                    departamento = ubicacion.prov,
                    pais = ubicacion.state
                };
            }
            catch (Exception ex)
            {

            }
            return mascotaUbicacion;
        }

        public async Task<IEnumerable<MascotaDTO>> ListarMascotaPorCuenta(int id_cuenta)
        {
            #region Variables
            IEnumerable<MascotaDTO> mascotas = Enumerable.Empty<MascotaDTO>();
            #endregion

            try
            {
                mascotas = await mascotaRepository.ObtenerMascotasPorCuenta(id_cuenta);
            }
            catch (Exception ex)
            {

            }
            return mascotas;
        }

        public async Task<bool> RegistrarHistorialPeso(ParRegistrarPeso parRegistrarPeso)
        {
            #region Variables
            bool result = false;
            var historialPeso = new Historial_pesoEntity();
            #endregion

            try
            {
                #region Transaccion
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    historialPeso = Metodos.PropertyCopier<Historial_pesoEntity>.Convert(parRegistrarPeso);

                    await this.historial_pesoRepository.Insert(historialPeso);

                    scope.Complete();
                    result = true;
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<IEnumerable<HistoricoPesoDTO>> ListarHistorialPesoPorMascota(int idMascota)
        {
            #region Variables
            IEnumerable<HistoricoPesoDTO> pesos = Enumerable.Empty<HistoricoPesoDTO>();
            #endregion

            try
            {
                pesos = await historial_pesoRepository.BuscarPesosPorMascota(idMascota);
            }
            catch (Exception ex)
            {

            }
            return pesos;
        }

        public async Task<IEnumerable<EspecieEntity>> RetornarEspecies()
        {
            #region Variables
            IEnumerable<EspecieEntity> especies = Enumerable.Empty<EspecieEntity>();
            #endregion

            try
            {
                especies = await especieRepository.GetAll();
            }
            catch (Exception ex)
            {

            }
            return especies;
        }

        public async Task<bool> RegistrarRazas(ParRegistrarRaza parRegistrarRaza)
        {
            #region Variables
            bool result = false;
            var raza = new RazaEntity();
            #endregion

            try
            {
                #region Transaccion
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    raza = Metodos.PropertyCopier<RazaEntity>.Convert(parRegistrarRaza);

                    await this.razaRepository.Insert(raza);

                    scope.Complete();
                    result = true;
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<IEnumerable<RazaEntity>> RetornarRazasPorEspecie(int idEspecie)
        {
            #region Variables
            IEnumerable<RazaEntity> razas = Enumerable.Empty<RazaEntity>();
            #endregion

            try
            {
                var busqueda = new Dictionary<string, object>();
                busqueda.Add(nameof(RazaEntity.id_especie), idEspecie);

                razas = await razaRepository.SearchByFieldsDictionary(busqueda);
            }
            catch (Exception ex)
            {

            }
            return razas;
        }
        public async Task<IEnumerable<RazaEntity>> RetornarRazas()
        {
            #region Variables
            IEnumerable<RazaEntity> razas = Enumerable.Empty<RazaEntity>();
            #endregion

            try
            {
                razas = await razaRepository.GetAll();
            }
            catch (Exception ex)
            {

            }
            return razas;
        }
    }
}
