using System.Collections.Generic;

namespace AutoGestion.Entidades.Seguridad
{
    public class PermisoSimple : IPermiso
    {
        public string Nombre { get; set; }

        public void Agregar(IPermiso permiso) { }
        public void Quitar(IPermiso permiso) { }
        public List<IPermiso> ObtenerHijos() => new();
    }
}
