using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormMascota.Helpers
{
    public interface IMostrarMensajes
    {
        Task MostrarMensajeError(string mensaje);
        Task MostrarMensajeExitoso(string mensaje);
    }
}
