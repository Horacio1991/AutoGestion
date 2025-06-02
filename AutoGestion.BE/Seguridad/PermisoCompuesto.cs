namespace AutoGestion.Entidades.Seguridad
{
    public class PermisoCompuesto : IPermiso
    {
        public string Nombre { get; set; }
        private List<IPermiso> _hijos = new();

        public void Agregar(IPermiso permiso) => _hijos.Add(permiso);

        public void Quitar(IPermiso permiso) => _hijos.Remove(permiso);

        public List<IPermiso> ObtenerHijos() => _hijos;
    }
}
