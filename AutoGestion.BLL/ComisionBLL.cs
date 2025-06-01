using AutoGestion.BE;
using AutoGestion.DAO;
using AutoGestion.Servicios;
using System;
using System.Collections.Generic;

namespace AutoGestion.BLL
{
    public class ComisionBLL
    {
        private readonly XmlRepository<Comision> _repo = new("comisiones.xml");

        public void Registrar(Comision comision)
        {
            comision.ID = GeneradorID.ObtenerID<Comision>();
            comision.Fecha = DateTime.Now;
            _repo.Agregar(comision);
        }

        public List<Comision> ObtenerTodas()
        {
            return _repo.ObtenerTodos();
        }
    }
}
