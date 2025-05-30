﻿using System.Collections.Generic;

namespace AutoGestion.Entidades.Seguridad
{
    public class UsuarioSerializable
    {
        public string Nombre { get; set; }
        public string Clave { get; set; }

        public string RolNombre { get; set; }  // ✅ nuevo campo
        public List<string> Permisos { get; set; } = new();
    }
}
