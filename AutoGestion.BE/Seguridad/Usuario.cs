namespace AutoGestion.Entidades.Seguridad
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public IPermiso Rol { get; set; }

        public bool TienePermiso(string permiso) =>
            Rol != null && Rol.TienePermiso(permiso);
    }
}
