using System.Collections.Generic;

namespace AutoGestion.Entidades.Seguridad
{
    public class PermisoCompuesto : IPermiso
    {
        public string Nombre { get; set; }
        private readonly List<IPermiso> _hijos = new();

        public void Agregar(IPermiso permiso)
        {
            if (!_hijos.Contains(permiso))
                _hijos.Add(permiso);
        }

        public void Quitar(IPermiso permiso)
        {
            _hijos.Remove(permiso);
        }

        public List<IPermiso> ObtenerHijos()
        {
            return _hijos;
        }
    }
}
