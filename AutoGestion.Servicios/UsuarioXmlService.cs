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
            // Asignar IDs si no tienen
            int siguienteID = usuarios.Any() ? usuarios.Max(u => u.ID) + 1 : 1;
            foreach (var u in usuarios.Where(x => x.ID == 0))
                u.ID = siguienteID++;

            var serializables = usuarios.Select(u => new UsuarioSerializable
            {
                ID = u.ID,                                    // IMPORTANTE
                Nombre = u.Nombre,
                Clave = u.Clave,
                Permisos = u.Rol != null ? ObtenerPermisos(u.Rol) : new List<string>()
            }).ToList();

            using var writer = new StreamWriter(ruta);
            var serializer = new XmlSerializer(typeof(List<UsuarioSerializable>));
            serializer.Serialize(writer, serializables);
        }



        public static List<Usuario> Leer()
        {
            if (!File.Exists(ruta)) return new List<Usuario>();

            using var reader = new StreamReader(ruta);
            var serializer = new XmlSerializer(typeof(List<UsuarioSerializable>));
            var serializables = (List<UsuarioSerializable>)serializer.Deserialize(reader);

            List<Usuario> usuarios = new();
            foreach (var s in serializables)
            {
                var usuario = new Usuario
                {
                    ID = s.ID,                                 // IMPORTANTE
                    Nombre = s.Nombre,
                    Clave = s.Clave
                };

                // Reconstruir Rol (si corresponde)
                var permisos = s.Permisos.Select(nombre => new PermisoSimple { Nombre = nombre }).ToList<IPermiso>();
                if (permisos.Any())
                {
                    var compuesto = new PermisoCompuesto { Nombre = "Rol Recuperado" };
                    foreach (var p in permisos)
                        compuesto.Agregar(p);

                    usuario.Rol = compuesto;
                }

                usuarios.Add(usuario);
            }

            return usuarios;
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
