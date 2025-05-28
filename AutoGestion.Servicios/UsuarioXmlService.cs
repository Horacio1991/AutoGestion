using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoGestion.Entidades.Seguridad;

namespace AutoGestion.Servicios
{
    public static class UsuarioXmlService
    {
        private static string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosXML", "usuarios.xml");

        public static void Guardar(List<Usuario> usuarios)
        {
            List<UsuarioSerializable> serializables = usuarios.Select(u => new UsuarioSerializable
            {
                Nombre = u.Nombre,
                Clave = u.Clave,
                RolNombre = u.Rol?.Nombre ?? "SinRol",
                Permisos = u.Rol != null ? ObtenerPermisos(u.Rol) : new List<string>()
            }).ToList();

            string carpeta = Path.GetDirectoryName(ruta);
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            var serializer = new XmlSerializer(typeof(List<UsuarioSerializable>));
            using var writer = new StreamWriter(ruta);
            serializer.Serialize(writer, serializables);
            
        }


        public static List<Usuario> Leer()
        {
            if (!File.Exists(ruta))
                return AgregarAdmin(new List<Usuario>());

            try
            {
                var serializer = new XmlSerializer(typeof(List<UsuarioSerializable>));
                using var reader = new StreamReader(ruta);
                var serializables = (List<UsuarioSerializable>)serializer.Deserialize(reader);

                var lista = serializables.Select(us => new Usuario
                {
                    Nombre = us.Nombre,
                    Clave = us.Clave,
                    Rol = CrearRolDesdePermisos(us.RolNombre, us.Permisos)
                }).ToList();

                return AgregarAdmin(lista);
            }
            catch
            {
                return AgregarAdmin(new List<Usuario>());
            }
        }

        private static List<string> ObtenerPermisos(IPermiso permiso)
        {
            List<string> permisos = new();
            if (permiso is PermisoSimple)
                permisos.Add(permiso.Nombre);
            else
                foreach (var hijo in permiso.ObtenerHijos())
                    permisos.AddRange(ObtenerPermisos(hijo));

            return permisos.Distinct().ToList();
        }

        private static PermisoCompuesto CrearRolDesdePermisos(string nombreRol, List<string> permisos)
        {
            var rol = new PermisoCompuesto { Nombre = nombreRol };
            foreach (var nombre in permisos)
                rol.Agregar(new PermisoSimple { Nombre = nombre });
            return rol;
        }


        private static List<Usuario> AgregarAdmin(List<Usuario> lista)
        {
            if (!lista.Any(u => u.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase)))
            {
                var todos = new PermisoCompuesto { Nombre = "SuperAdmin" };

                // Agregá todos los permisos del sistema
                string[] permisos = {
            "Solicitar Modelo", "Realizar Pago", "Autorizar Venta", "Emitir Factura", "Realizar Entrega",
            "Registrar Oferta", "Evaluar Vehículo", "Tasar Vehículo", "Registrar Compra",
            "Registrar Comisión", "Consultar Comisiones",
            "Registrar Turno", "Registrar Asistencia",
            "Asignar Roles"
        };

                foreach (var p in permisos)
                    todos.Agregar(new PermisoSimple { Nombre = p });

                lista.Add(new Usuario
                {
                    Nombre = "admin",
                    Clave = "123",
                    Rol = todos
                });
            }

            return lista;
        }

    }
}
