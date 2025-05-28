namespace AutoGestion.Entidades.Seguridad
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public IPermiso Rol { get; set; }

        public bool TienePermiso(string nombrePermiso)
        {
            return BuscarPermiso(Rol, nombrePermiso);
        }

        private bool BuscarPermiso(IPermiso permiso, string nombre)
        {
            if (permiso.Nombre == nombre)
                return true;

            foreach (var hijo in permiso.ObtenerHijos())
                if (BuscarPermiso(hijo, nombre))
                    return true;

            return false;
        }
    }
}
