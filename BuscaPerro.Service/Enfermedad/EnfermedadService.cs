using BuscaPerro.Base.Generico;
using BuscaPerro.Domain.Enfermedad.DTO;
using BuscaPerro.Domain.Enfermedad.Entidad;
using BuscaPerro.Domain.Enfermedad.Interfaces.Services;
using BuscaPerro.Domain.Enfermedad.Models;
using BuscaPerro.Domain.Interfaz.Enfermedad.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BuscaPerro.Service.Enfermedad
{
    public class EnfermedadService : IEnfermedadService
    {
        #region Instanciar repositorios
        private IEnfermedadRepository enfermedadRepository;
        private IHistorico_enfermedadesRepository historico_EnfermedadesRepository;

        public EnfermedadService(IEnfermedadRepository enfermedadRepository,
            IHistorico_enfermedadesRepository historico_EnfermedadesRepository)
        {
            this.enfermedadRepository = enfermedadRepository;
            this.historico_EnfermedadesRepository = historico_EnfermedadesRepository;
        }
        #endregion

        public async Task<bool> RegistrarEnfermedad(ParRegistrarEnfermedad parRegistrarEnfermedad)
        {
            #region Variables
            bool result = false;
            var enfermedad = new EnfermedadEntity();
            #endregion

            try
            {
                #region Transaccion
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    enfermedad = Metodos.PropertyCopier<EnfermedadEntity>.Convert(parRegistrarEnfermedad);
                    await enfermedadRepository.Insert(enfermedad);

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

        public async Task<bool> RegistrarEnfermedadHistorico(ParRegistrarHistoricoEnfermedad parRegistrarHistoricoEnfermedad)
        {
            #region Variables
            bool result = false;
            var historicoEnfermedades = new Historico_enfermedadesEntity();
            #endregion

            try
            {
                #region Transaccion
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    historicoEnfermedades = Metodos.PropertyCopier<Historico_enfermedadesEntity>.Convert(parRegistrarHistoricoEnfermedad);
                    await historico_EnfermedadesRepository.Insert(historicoEnfermedades);

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

        public async Task<IEnumerable<HistoricoEnfermedadDTO>> ListarHistoricoEnfermedad(int idMascota)
        {
            #region Variables
            IEnumerable<HistoricoEnfermedadDTO> historicoEnfermedades = Enumerable.Empty<HistoricoEnfermedadDTO>();
            #endregion

            try
            {
                historicoEnfermedades = await historico_EnfermedadesRepository.ObtenerHistoricoMascota(idMascota);
            }
            catch (Exception ex)
            {

            }
            return historicoEnfermedades;
        }

        public async Task<IEnumerable<EnfermedadEntity>> ListarEnfermedades()
        {
            #region Variables
            IEnumerable<EnfermedadEntity> enfermedades = Enumerable.Empty<EnfermedadEntity>();
            #endregion

            try
            {
               enfermedades = await this.enfermedadRepository.GetAll();
            }
            catch (Exception ex)
            {

            }
            return enfermedades;
        }
    }
}
