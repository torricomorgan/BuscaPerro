using BuscaPerro.Base.Generico;
using BuscaPerro.Domain.Autentificacion.DTO;
using BuscaPerro.Domain.Autentificacion.Interfaces;
using BuscaPerro.Domain.Autentificacion.Models;
using BuscaPerro.Domain.Cuenta.Entidad;
using BuscaPerro.Domain.Interfaz.Cuenta.Repository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BuscaPerro.Service.Autotentificacion
{
    public class AutorizacionService : IAutorizacionService
    {
        #region Instanciar repositorios
        private ICuentaRepository cuentaRepository;
        private IPersonaRepository personaRepository;
        private readonly IConfiguration _configuration;

        public AutorizacionService(ICuentaRepository cuentaRepository,
            IPersonaRepository personaRepository,
            IConfiguration configuration)
        {
            this.cuentaRepository = cuentaRepository;
            this.personaRepository = personaRepository;
            this._configuration = configuration;
        }
        #endregion

        public async Task<AutorizacionDTO> IniciarSesion(ParLogIn parLogIn)
        {
            #region Variables
            var cuenta = new CuentaEntity();
            var persona = new PersonaEntity();
            var sesion = new AutorizacionDTO() { exito = false};
            #endregion

            try
            {
                var parObtenerCuenta = parLogIn;
                // Tu código para validar que el usuario ingresado es válido
                var usuarioEntidad = new CuentaEntity();
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken createdToken = null;
                parObtenerCuenta.contrasenia = Metodos.GenerarHash(parObtenerCuenta.contrasenia);
                var usuarioResultado = this.cuentaRepository.SearchByFields(parObtenerCuenta).Result;
                if (usuarioResultado.Any())
                {
                    usuarioEntidad = usuarioResultado.First();
                }
                else { return sesion; }

                var secretKey = _configuration.GetSection("SecretKey").Value;
                var tiempoDia = Convert.ToInt32(_configuration.GetSection("Dia").Value);

                var key = Encoding.ASCII.GetBytes(secretKey);

                // Creamos los claims (pertenencias, características) del usuario
                var claims = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, "a79b2e64-a4de-4f3a-8cf6-a68ba400db24"),
            new Claim(ClaimTypes.Email, usuarioEntidad.usuario)
            });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    // Nuestro token va a durar un día
                    //Expires = DateTime.UtcNow.AddMinutes(tiempoMinuto),
                    Expires = DateTime.UtcNow.AddDays(tiempoDia),
                    // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                usuarioEntidad.contrasenia = "******";
                createdToken = tokenHandler.CreateToken(tokenDescriptor);
                sesion.exito = true;
                sesion.token = tokenHandler.WriteToken(createdToken);
                sesion.id_cuenta = usuarioEntidad.id_cuenta;
                sesion.id_persona = usuarioEntidad.id_persona;
            }
            catch (Exception ex)
            {

            }
            return sesion;
        }
    }
}
