using BuscaPerro.Base.Generico;
using BuscaPerro.Domain.Interfaz.Vacunacion.Repository;
using BuscaPerro.Domain.Vacunacion.DTO;
using BuscaPerro.Domain.Vacunacion.Entidad;
using BuscaPerro.Domain.Vacunacion.Interfaces.Services;
using BuscaPerro.Domain.Vacunacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BuscaPerro.Service.Vacunacion
{
    public class VacunacionService : IVacunacionService
    {
        #region Instanciar repositorios
        private IVacunaRepository vacunaRepository;
        private ICalendario_vacunacionRepository calendarioRepository;
        private IProveedor_vacunaRepository proveedorRepository;

        public VacunacionService(IVacunaRepository vacunaRepository,
            ICalendario_vacunacionRepository calendarioRepository,
            IProveedor_vacunaRepository proveedorRepository)
        {
            this.vacunaRepository = vacunaRepository;
            this.calendarioRepository = calendarioRepository;
            this.proveedorRepository = proveedorRepository;
        }
        #endregion

        public async Task<bool> RegistrarVacuna(ParRegistrarVacuna parRegistrarVacuna)
        {
            #region Variables
            bool result = false;
            var vacuna = new VacunaEntity();
            #endregion

            try
            {
                #region Transaccion
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    vacuna = Metodos.PropertyCopier<VacunaEntity>.Convert(parRegistrarVacuna);
                    await vacunaRepository.Insert(vacuna);

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

        public async Task<bool> RegistrarVacunaACalendario(ParRegistrarVacunaCalendario parRegistrarVacunaCalendario)
        {
            #region Variables
            bool result = false;
            var vacunaCalendario = new Calendario_vacunacionEntity();
            #endregion

            try
            {
                #region Transaccion
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    vacunaCalendario = Metodos.PropertyCopier<Calendario_vacunacionEntity>.Convert(parRegistrarVacunaCalendario);
                    await calendarioRepository.Insert(vacunaCalendario);

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

        public async Task<IEnumerable<VacunaCalendarioDTO>> ListarCalendarioVacunas(int idMascota)
        {
            #region Variables
            IEnumerable<VacunaCalendarioDTO> vacunasCalendario = Enumerable.Empty<VacunaCalendarioDTO>();
            #endregion

            try
            {
                vacunasCalendario = await calendarioRepository.ObtenerVacunasMascota(idMascota);
            }
            catch (Exception ex)
            {

            }
            return vacunasCalendario;
        }

        public async Task<IEnumerable<VacunaDTO>> ListarVacunas()
        {
            #region Variables
            IEnumerable<VacunaDTO> vacunas = Enumerable.Empty<VacunaDTO>();
            #endregion

            try
            {
                vacunas = await vacunaRepository.ObtenerVacunas();
            }
            catch (Exception ex)
            {

            }
            return vacunas;
        }

        public async Task<IEnumerable<Proveedor_vacunaEntity>> ListarProveedoresVacunas()
        {
            #region Variables
            IEnumerable<Proveedor_vacunaEntity> proveedores = Enumerable.Empty<Proveedor_vacunaEntity>();
            #endregion

            try
            {
                proveedores = await proveedorRepository.GetAll();
            }
            catch (Exception ex)
            {

            }
            return proveedores;
        }

    }
}
