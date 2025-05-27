using AutoGestion.BE;
using AutoGestion.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class TurnoBLL
    {
        private readonly XmlRepository<Turno> _repo = new("turnos.xml");

        public bool VerificarDisponibilidad(DateTime fecha, TimeSpan hora)
        {
            return !_repo.ObtenerTodos().Any(t => t.Fecha.Date == fecha.Date && t.Hora == hora);
        }

        public void RegistrarTurno(Turno turno)
        {
            turno.ID = ObtenerNuevoID();
            turno.Asistencia = "Pendiente";
            _repo.Agregar(turno);
        }

        private int ObtenerNuevoID()
        {
            var lista = _repo.ObtenerTodos();
            return lista.Any() ? lista.Max(t => t.ID) + 1 : 1;
        }

        public List<Turno> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }

        public List<Turno> ObtenerTurnosVencidos()
        {
            return _repo.ObtenerTodos()
                .Where(t => t.Fecha.Date <= DateTime.Today && t.Asistencia == "Pendiente")
                .ToList();
        }

        public void RegistrarAsistencia(int id, string estado)
        {
            var lista = _repo.ObtenerTodos();
            var turno = lista.FirstOrDefault(t => t.ID == id);
            if (turno != null)
            {
                turno.Asistencia = estado;
                _repo.GuardarLista(lista);
            }
        }

        public void RegistrarObservaciones(int id, string texto)
        {
            var lista = _repo.ObtenerTodos();
            var turno = lista.FirstOrDefault(t => t.ID == id);
            if (turno != null)
            {
                turno.Asistencia = texto; 
                _repo.GuardarLista(lista);
            }
        }

    }
}
