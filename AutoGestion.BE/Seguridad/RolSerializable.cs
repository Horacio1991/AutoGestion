﻿using System.Collections.Generic;

namespace AutoGestion.Entidades.Seguridad
{
    public class RolSerializable
    {
        public string Nombre { get; set; }
        public List<string> Permisos { get; set; } = new();  // Nombres de PermisoCompleto
    }
}
