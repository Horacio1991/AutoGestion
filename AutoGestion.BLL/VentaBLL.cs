using AutoGestion.BE;
using AutoGestion.DAO;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class VentaBLL
    {
        private readonly XmlRepository<Venta> _repo = new("ventas.xml");

        public List<Venta> ObtenerVentasPendientes()
        {
            return _repo.ObtenerTodos().Where(v => v.Estado == "Pendiente").ToList();
        }

        public Venta ObtenerDetalleVenta(int index)
        {
            return _repo.ObtenerTodos()[index];
        }

        public void AutorizarVenta(int index)
        {
            var lista = _repo.ObtenerTodos();
            lista[index].Estado = "Autorizada";
            _repo.GuardarLista(lista);
        }

        public void RechazarVenta(int index)
        {
            var lista = _repo.ObtenerTodos();
            lista[index].Estado = "Rechazada";
            _repo.GuardarLista(lista);
        }

        public void RegistrarVenta(Venta venta)
        {
            _repo.Agregar(venta);
        }
    }
}
