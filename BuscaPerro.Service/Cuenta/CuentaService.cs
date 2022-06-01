using BuscaPerro.Base.Generico;
using BuscaPerro.Domain.Cuenta.DTO;
using BuscaPerro.Domain.Cuenta.Entidad;
using BuscaPerro.Domain.Cuenta.Interfaces.Services;
using BuscaPerro.Domain.Cuenta.Models;
using BuscaPerro.Domain.Interfaz.Cuenta.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BuscaPerro.Service.Cuenta
{
    public class CuentaService : ICuentaService
    {
        #region Instanciar repositorios
        private ICuentaRepository cuentaRepository;
        private IPersonaRepository personaRepository;

        public CuentaService(ICuentaRepository cuentaRepository,
            IPersonaRepository personaRepository)
        {
            this.cuentaRepository = cuentaRepository;
            this.personaRepository = personaRepository;
        }
        #endregion

        public async Task<bool> RegistrarCuenta(ParRegistrarCuenta parRegistrarCuenta)
        {
            #region Variables
            bool result = false;
            var cuenta = new CuentaEntity();
            var persona = new PersonaEntity();
            int idPersona = 0;
            #endregion

            try
            {
                #region Transaccion
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    persona = Metodos.PropertyCopier<PersonaEntity>.Convert(parRegistrarCuenta);
                    idPersona = await this.personaRepository.Insert(persona);

                    cuenta = new CuentaEntity()
                    {
                        id_persona = idPersona,
                        usuario = parRegistrarCuenta.email,
                        contrasenia = Metodos.GenerarHash(parRegistrarCuenta.contrasenia)
                    };

                    await this.cuentaRepository.Insert(cuenta);

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
        public async Task<CuentaDTO> RetornarPerfilCuenta(int idCuenta)
        {
            #region Variables
            var cuenta = new CuentaEntity();
            var persona = new PersonaEntity();
            var perfil = new CuentaDTO();
            #endregion

            try
            {
                cuenta = await this.cuentaRepository.Get(idCuenta);
                persona = await this.personaRepository.Get(cuenta.id_persona);

                perfil = Metodos.PropertyCopier<CuentaDTO>.Convert(persona);
                perfil.id_cuenta = cuenta.id_cuenta;
                perfil.usuario = cuenta.usuario;
            }
            catch (Exception ex)
            {

            }
            return perfil;
        }
    }
}
