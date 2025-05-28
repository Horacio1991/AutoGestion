using AutoGestion.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGestion.BE.Seguridad
{
    public static class Sesion
    {
        public static Usuario UsuarioActual { get; set; }
    }

}
