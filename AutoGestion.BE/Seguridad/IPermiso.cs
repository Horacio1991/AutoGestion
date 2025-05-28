using System.Collections.Generic;

namespace AutoGestion.Entidades.Seguridad
{
    public interface IPermiso
    {
        string Nombre { get; set; }
        List<IPermiso> ObtenerHijos();
        void Agregar(IPermiso permiso);
        bool TienePermiso(string permiso);
    }
}
