using AutoGestion.BE;
using AutoGestion.DAO;
using System.Collections.Generic;

namespace AutoGestion.BLL
{
    public class PagoBLL
    {
        private readonly XmlRepository<Pago> _repo = new("pagos.xml");

        
        public bool RegistrarPago(Pago pago)
        {
            var lista = _repo.ObtenerTodos();
            lista.Add(pago);
            _repo.GuardarLista(lista);
            return true;
        }

        public List<Pago> ObtenerTodosLosPagos()
        {
            return _repo.ObtenerTodos();
        }
    }
}
