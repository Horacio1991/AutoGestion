using AutoGestion.BE;
using AutoGestion.DAO;
using AutoGestion.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class TurnoBLL
    {
        private readonly XmlRepository<Turno> _repo = new("turnos.xml");

        public bool EstaDisponible(DateTime fecha, TimeSpan hora, Vehiculo vehiculo)
        {
            return !_repo.ObtenerTodos().Any(t =>
                t.Fecha.Date == fecha.Date &&
                t.Hora == hora &&
                t.Vehiculo.Dominio == vehiculo.Dominio);
        }

        public void RegistrarTurno(Cliente cliente, Vehiculo vehiculo, DateTime fecha, TimeSpan hora)
        {
            var turno = new Turno
            {
                ID = GeneradorID.ObtenerID<Turno>(),
                Cliente = cliente,
                Vehiculo = vehiculo,
                Fecha = fecha.Date,
                Hora = hora,
                Asistencia = "Pendiente",
                Observaciones = ""
            };

            _repo.Agregar(turno);
        }

        public List<Turno> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }
    }
}
