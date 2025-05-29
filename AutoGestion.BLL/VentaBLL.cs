using AutoGestion.BE;
using AutoGestion.DAO;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class VentaBLL
    {
        private readonly XmlRepository<Venta> _repo = new("ventas.xml");

        private int ObtenerNuevoID()
        {
            var lista = _repo.ObtenerTodos();
            return lista.Any() ? lista.Max(v => v.ID) + 1 : 1;
        }
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

        public void MarcarComoFacturada(int id)
        {
            var lista = _repo.ObtenerTodos();
            var venta = lista.FirstOrDefault(v => v.ID == id);
            if (venta != null)
            {
                venta.Estado = "Facturada";
                _repo.GuardarLista(lista);
            }
        }

        public void MarcarComoEntregada(int id)
        {
            var lista = _repo.ObtenerTodos();
            var venta = lista.FirstOrDefault(v => v.ID == id);
            if (venta != null)
            {
                venta.Estado = "Entregada";
                _repo.GuardarLista(lista);
            }
        }

        public List<Venta> ObtenerVentasSinComision(List<Comision> comisiones)
        {
            var ventas = _repo.ObtenerTodos().Where(v => v.Estado == "Entregada").ToList();
            var idsConComision = comisiones.Select(c => c.Venta.ID);
            return ventas.Where(v => !idsConComision.Contains(v.ID)).ToList();
        }

        public void FinalizarVenta(Venta venta)
        {
            var lista = _repo.ObtenerTodos();
            lista.Add(venta);
            _repo.GuardarLista(lista);
        }



    }
}
