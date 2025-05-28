using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.Entidades.Seguridad
{
    public class PermisoCompuesto : IPermiso
    {
        public string Nombre { get; set; }
        private List<IPermiso> hijos = new();

        public void Agregar(IPermiso permiso)
        {
            if (permiso != null)
                hijos.Add(permiso);
        }

        public List<IPermiso> ObtenerHijos() => hijos;

        public bool TienePermiso(string permiso) =>
            hijos.Any(h => h.TienePermiso(permiso));
    }
}
