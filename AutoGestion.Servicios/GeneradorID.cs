using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AutoGestion.Servicios
{
    public static class GeneradorID
    {
        public static int ObtenerID<T>()
        {
            string nombreArchivo = typeof(T).Name.ToLower() + "s.xml";
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosXML", nombreArchivo);

            if (!File.Exists(ruta))
                return 1;

            var serializer = new XmlSerializer(typeof(List<T>));
            using var stream = new FileStream(ruta, FileMode.Open);
            var lista = (List<T>)serializer.Deserialize(stream);

            var idProp = typeof(T).GetProperty("ID");
            if (idProp == null) return 1;

            var ids = lista.Select(item => (int?)idProp.GetValue(item)).Where(i => i.HasValue).Select(i => i.Value);
            return ids.Any() ? ids.Max() + 1 : 1;
        }
    }
}
