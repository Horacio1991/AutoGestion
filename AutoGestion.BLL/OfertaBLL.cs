using AutoGestion.BE;
using AutoGestion.DAO;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class OfertaBLL
    {
        private readonly XmlRepository<OfertaCompra> _repo = new("ofertas.xml");

        public bool ValidarOfertaDuplicada(Vehiculo vehiculo)
        {
            return _repo.ObtenerTodos()
                        .Any(o => o.Vehiculo.Dominio == vehiculo.Dominio);
        }

        public void RegistrarOferta(OfertaCompra oferta)
        {
            oferta.ID = ObtenerNuevoID();
            _repo.Agregar(oferta);
        }

        private int ObtenerNuevoID()
        {
            var lista = _repo.ObtenerTodos();
            return lista.Any() ? lista.Max(o => o.ID) + 1 : 1;
        }

        public List<OfertaCompra> ObtenerTodas()
        {
            return _repo.ObtenerTodos();
        }
    }
}
