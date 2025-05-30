using AutoGestion.BE;
using AutoGestion.DAO;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class EvaluacionBLL
    {
        private readonly XmlRepository<EvaluacionTecnica> _repo = new("evaluaciones.xml");

        public void GuardarEvaluacion(OfertaCompra oferta, EvaluacionTecnica evaluacion)
        {
            evaluacion.ID = AutoGestion.Servicios.GeneradorID.ObtenerID<EvaluacionTecnica>();
            var repo = new XmlRepository<EvaluacionTecnica>("evaluaciones.xml");
            var lista = repo.ObtenerTodos();
            lista.Add(evaluacion);
            repo.GuardarLista(lista);

            // Asociar por Oferta si hace falta otra lógica futura
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
