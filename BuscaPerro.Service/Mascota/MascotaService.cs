﻿using BuscaPerro.Base.Generico;
using BuscaPerro.Domain.Interfaz.Mascota.Repository;
using BuscaPerro.Domain.Mascota.DTO;
using BuscaPerro.Domain.Mascota.Entidad;
using BuscaPerro.Domain.Mascota.Interfaces.Services;
using BuscaPerro.Domain.Mascota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BuscaPerro.Service.Mascota
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

        public async Task<IEnumerable<RazaEntity>> RetornarRazas(int idEspecie)
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
    }
}
