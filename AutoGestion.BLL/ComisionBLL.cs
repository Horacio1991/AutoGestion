using AutoGestion.BE;
using AutoGestion.DAO;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class ComisionBLL
    {
        private readonly XmlRepository<Comision> _repo = new("comisiones.xml");

        public void RegistrarComision(Comision comision)
        {
            comision.ID = ObtenerNuevoID();
            _repo.Agregar(comision);
        }

        public List<Comision> ObtenerTodas()
        {
            return _repo.ObtenerTodos();
        }

        private int ObtenerNuevoID()
        {
            var lista = _repo.ObtenerTodos();
            return lista.Any() ? lista.Max(c => c.ID) + 1 : 1;
        }
    }
}
