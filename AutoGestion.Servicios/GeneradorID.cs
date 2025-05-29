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
            string tipo = typeof(T).Name.ToLower();
            string nombreArchivo = tipo + "s.xml";
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosXML", nombreArchivo);

            if (!File.Exists(ruta))
                return 1;

            var serializer = new XmlSerializer(typeof(List<T>));
            using var reader = new StreamReader(ruta);
            var lista = (List<T>)serializer.Deserialize(reader);

            // Busca la propiedad "ID" y obtiene el máximo
            var prop = typeof(T).GetProperty("ID");
            if (prop == null)
                throw new Exception("La clase no tiene propiedad ID.");

            var maxId = lista
                .Select(x => (int)prop.GetValue(x))
                .DefaultIfEmpty(0)
                .Max();

            return maxId + 1;
        }
    }
}
