using AutoGestion.BE;
using AutoGestion.DAO;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class EvaluacionBLL
    {
        private readonly XmlRepository<EvaluacionTecnica> _repo = new("evaluaciones.xml");

        public void GuardarEvaluacion(EvaluacionTecnica evaluacion)
        {
            evaluacion.ID = ObtenerNuevoID();
            _repo.Agregar(evaluacion);
        }

        public int ObtenerNuevoID()
        {
            var lista = _repo.ObtenerTodos();
            return lista.Any() ? lista.Max(e => e.ID) + 1 : 1;
        }

        public List<EvaluacionTecnica> ObtenerTodas()
        {
            return _repo.ObtenerTodos();
        }
    }
}
