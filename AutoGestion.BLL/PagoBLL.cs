using AutoGestion.BE;
using AutoGestion.DAO;
using System.Collections.Generic;

namespace AutoGestion.BLL
{
    public class PagoBLL
    {
        private readonly XmlRepository<Pago> _repo = new("pagos.xml");

        private int ObtenerNuevoID()
        {
            var lista = _repo.ObtenerTodos();
            return lista.Any() ? lista.Max(p => p.ID) + 1 : 1;
        }
        public bool RegistrarPago(Pago pago)
        {
            _repo.Agregar(pago);
            return true;
        }

        public List<Pago> ObtenerTodosLosPagos()
        {
            return _repo.ObtenerTodos();
        }
    }
}
