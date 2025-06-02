namespace AutoGestion.Entidades.Seguridad
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; } // Encriptado
        public IPermiso Rol { get; set; } // Composite Pattern
    }
}
