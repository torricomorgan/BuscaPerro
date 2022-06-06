using BuscaPerro.Domain.Veterinaria.DTO;
using BuscaPerro.Domain.Veterinaria.Interfaces;
using BuscaPerro.Domain.Veterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Veterinaria.Services
{
    public class VeterinariaService : IVeterinariaService
    {
        public async Task<IEnumerable<UbicacionVeterinariasDTO>> ListarVeterinariasCercanas()
        {
            #region Variables
            List<UbicacionVeterinariasDTO> lista = new List<UbicacionVeterinariasDTO>();
            HttpClient client = new HttpClient();
            string json = String.Empty;
            #endregion

            try
            {
                json = await client.GetStringAsync("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=-17.799084,-63.173673&radius=1500&type=veterinary_care&key=AIzaSyD4cfvPvSKAlc_LBuvugnFvaeXdo-2BD2U");
                var aux = JsonSerializer.Deserialize<Rootobject>(json);
                if (aux != null)
                {
                    foreach (var vet in aux.results)
                    {
                        var ubicacionVeterinaria = new UbicacionVeterinariasDTO();
                        ubicacionVeterinaria.nombre = vet.name;
                        ubicacionVeterinaria.estado = vet.business_status;
                        ubicacionVeterinaria.calificacion_usuarios = vet.user_ratings_total;
                        ubicacionVeterinaria.calificacion = vet.rating;
                        ubicacionVeterinaria.ubicacion = vet.vicinity;
                        ubicacionVeterinaria.lat = vet.geometry.location.lat;
                        ubicacionVeterinaria.lng = vet.geometry.location.lng;
                        lista.Add(ubicacionVeterinaria);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return lista.AsEnumerable();
        }
    }
}
