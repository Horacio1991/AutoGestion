using AutoGestion.BE;
using AutoGestion.DAO;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class FacturaBLL
    {
        private readonly XmlRepository<Factura> _repo = new("facturas.xml");

        public Factura EmitirFactura(Factura factura)
        {
            factura.ID = ObtenerNuevoID();
            _repo.Agregar(factura);
            return factura;
        }

        private int ObtenerNuevoID()
        {
            var lista = _repo.ObtenerTodos();
            return lista.Any() ? lista.Max(f => f.ID) + 1 : 1;
        }

        public List<Factura> ObtenerTodas()
        {
            return _repo.ObtenerTodos();
        }
    }
}
