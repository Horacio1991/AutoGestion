using System.Collections.Generic;

namespace AutoGestion.Entidades.Seguridad
{
    public class PermisoSimple : IPermiso
    {
        public string Nombre { get; set; }

        public List<IPermiso> ObtenerHijos() => new();
        public void Agregar(IPermiso permiso) { /* no hace nada */ }

        public bool TienePermiso(string permiso) =>
            Nombre.Equals(permiso, System.StringComparison.OrdinalIgnoreCase);
    }
}
