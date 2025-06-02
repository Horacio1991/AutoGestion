using AutoGestion.Entidades.Seguridad;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AutoGestion.Servicios
{
    public static class RolXmlService
    {
        private static string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosXML", "roles.xml");

        public static void Guardar(List<PermisoCompuesto> roles)
        {
            using var writer = new StreamWriter(ruta);
            var serializer = new XmlSerializer(typeof(List<PermisoCompuesto>), new[] { typeof(PermisoSimple), typeof(PermisoCompuesto) });
            serializer.Serialize(writer, roles);
        }

        public static List<PermisoCompuesto> Leer()
        {
            if (!File.Exists(ruta))
                return new List<PermisoCompuesto>();

            using var reader = new StreamReader(ruta);
            var serializer = new XmlSerializer(typeof(List<PermisoCompuesto>), new[] { typeof(PermisoSimple), typeof(PermisoCompuesto) });
            return (List<PermisoCompuesto>)serializer.Deserialize(reader);
        }
    }
}
