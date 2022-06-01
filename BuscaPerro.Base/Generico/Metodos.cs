using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace BuscaPerro.Base.Generico
{
    public static class Metodos
    {
        public static string GenerarHash(string jsonDato)
        {

            var res = "";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(jsonDato));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                res = Convert.ToString(builder);
                //  return builder.ToString();
            }
            return res;
        }
        public static class PropertyCopier<T> where T : new()
        {
            public static T Convert(object source)
            {
                var sourceProperties = source.GetType().GetProperties();
                var child = new T();
                var childProperties = child.GetType().GetProperties();
                foreach (var parentProperty in sourceProperties)
                {
                    foreach (var childProperty in childProperties)
                    {
                        if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                        {
                            childProperty.SetValue(child, parentProperty.GetValue(source));
                            break;
                        }
                    }
                }
                return child;
            }
        }
        public static T DiccionarioAClase<T>(IDictionary<string, object> diccionario) where T : class, new()
        {
            var clase = new T();
            var claseTipo = clase.GetType();

            foreach (var obj in diccionario)
            {
                var atributo = claseTipo.GetProperty(obj.Key);
                var tipo = atributo.PropertyType;
                atributo.SetValue(clase, Convert.ChangeType(obj.Value, tipo), null);
            }
            return clase;
        }
        public static Dictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );

        }
    }
}
