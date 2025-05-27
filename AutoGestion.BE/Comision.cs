using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGestion.BE
{
    [Serializable]
    public class Comision
    {
        public int ID { get; set; }
        public Venta Venta { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Monto => Venta != null ? Venta.Total * (Porcentaje / 100) : 0;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Estado { get; set; } // Pendiente / Pagada
    }
}
