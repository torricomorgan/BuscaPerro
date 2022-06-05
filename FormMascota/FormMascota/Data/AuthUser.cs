
using FormMascota.Dtos;
using FormMascota.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FormMascota.Data
{
    public class AuthUser
    {
        public  bool Authentication(LoginRespuestaDTO DatosUser)
        {
            if (DatosUser.exito)
            {
                return true;
            }else
            {
                return false;
            }   
        }

      
    }
}
