using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGestion.Vista.Modelos
{
    public class VentaVista
    {
        public int ID { get; set; }
        public string Cliente { get; set; }
        public string Vehiculo { get; set; }
        public string TipoPago { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }
    }
}

