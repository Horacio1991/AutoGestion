﻿namespace AutoGestion.Entidades.Seguridad
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public IPermiso Rol { get; set; }

        public bool TienePermiso(string permiso) =>
            Rol != null && Rol.TienePermiso(permiso);
    }
}
