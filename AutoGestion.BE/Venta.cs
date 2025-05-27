using System;

namespace AutoGestion.BE
{
    [Serializable]
    public class Venta
    {
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Pago Pago { get; set; }
        public string Estado { get; set; } // "Pendiente", "Autorizada", "Rechazada"
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Total => Pago?.Monto ?? 0;
    }
}
