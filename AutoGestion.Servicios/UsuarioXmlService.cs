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

            var serializables = usuarios.Select(u => new UsuarioSerializable
            {
                ID = u.ID,
                Nombre = u.Nombre,
                Clave = u.Clave,
                Permisos = u.Rol != null ? ObtenerPermisos(u.Rol) : new List<string>(),
                RolID = u.Rol is PermisoCompuesto pc ? pc.ID : null

            }).ToList();

            using var writer = new StreamWriter(ruta);
            var serializer = new XmlSerializer(typeof(List<UsuarioSerializable>));
            serializer.Serialize(writer, serializables);
        }

        public static List<Usuario> Leer()
        {
            if (!File.Exists(ruta))
                return AgregarUsuarioAdmin(new List<Usuario>());

            using var stream = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.Read);
            var serializer = new XmlSerializer(typeof(List<UsuarioSerializable>));
            var serializables = (List<UsuarioSerializable>)serializer.Deserialize(stream);

            List<Usuario> usuarios = new();
            foreach (var s in serializables)
            {
                var usuario = new Usuario
                {
                    ID = s.ID,
                    Nombre = s.Nombre,
                    Clave = s.Clave
                };

                if (s.RolID.HasValue)
                {
                    var rol = RolXmlService.Leer().FirstOrDefault(r => r.ID == s.RolID.Value);
                    if (rol != null)
                        usuario.Rol = rol;
                }

                var permisos = s.Permisos.Select(nombre => new PermisoSimple { Nombre = nombre }).Cast<IPermiso>().ToList();

                if (permisos.Any())
                {
                    var compuesto = new PermisoCompuesto { Nombre = "Rol Recuperado" };
                    foreach (var p in permisos)
                        compuesto.Agregar(p);
                    usuario.Rol = compuesto;
                }

                usuarios.Add(usuario);
            }

            return AgregarUsuarioAdmin(usuarios);
        }

        public static void Eliminar(string nombreUsuario)
        {
            var usuarios = Leer();
            usuarios.RemoveAll(u => u.Nombre.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
            Guardar(usuarios);
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

        private static List<Usuario> AgregarUsuarioAdmin(List<Usuario> lista)
        {
            if (!lista.Any(u => u.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase)))
            {
                var permisos = PermisoCompletoXmlService.Leer();

                var todos = new PermisoCompuesto
                {
                    ID = GeneradorID.ObtenerID<PermisoCompuesto>(),
                    Nombre = "SuperAdmin"
                };

                foreach (var permiso in permisos)
                    todos.Agregar(permiso); // Composite

                lista.Add(new Usuario
                {
                    ID = GeneradorID.ObtenerID<Usuario>(),
                    Nombre = "admin",
                    Clave = Encriptacion.EncriptarPassword("123"),
                    Rol = todos
                });

                Guardar(lista); // lo guarda automáticamente
            }

            return lista;
        }
    }
}
