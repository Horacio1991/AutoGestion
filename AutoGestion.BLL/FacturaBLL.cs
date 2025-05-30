using AutoGestion.BE;
using AutoGestion.DAO;
using AutoGestion.Servicios;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class FacturaBLL
    {
        private readonly XmlRepository<Factura> _repo = new("facturas.xml");

        public Factura EmitirFactura(Factura factura)
        {
            factura.ID = GeneradorID.ObtenerID<Factura>();
            factura.Fecha = DateTime.Now;

            var lista = _repo.ObtenerTodos();
            lista.Add(factura);
            _repo.GuardarLista(lista);

            return factura;
        }

        public List<Factura> ObtenerTodas()
        {
            return _repo.ObtenerTodos();
        }
    }
}
