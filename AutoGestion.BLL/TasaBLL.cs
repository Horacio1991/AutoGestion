using AutoGestion.BE;
using AutoGestion.DAO;
using AutoGestion.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class TasaBLL
    {
        private readonly XmlRepository<Tasacion> _repo = new("tasaciones.xml");

        public void RegistrarTasacion(OfertaCompra oferta, decimal valorFinal)
        {
            var nueva = new Tasacion
            {
                ID = GeneradorID.ObtenerID<Tasacion>(), // ✅ ID único
                Oferta = oferta,
                ValorFinal = valorFinal,
                Fecha = DateTime.Now
            };

            _repo.Agregar(nueva);
        }

        public RangoTasacion CalcularRangoTasacion(string modelo, string estadoMotor, int kilometraje)
        {
            // Lógica ficticia y simple para demo
            decimal baseMin = 1500000;
            decimal baseMax = 2200000;

            if (estadoMotor.Contains("Excelente"))
            {
                baseMin += 250000;
                baseMax += 350000;
            }
            else if (estadoMotor.Contains("Regular"))
            {
                baseMin -= 250000;
                baseMax -= 350000;
            }

            if (kilometraje < 50000)
            {
                baseMin += 150000;
                baseMax += 200000;
            }
            else if (kilometraje > 150000)
            {
                baseMin -= 150000;
                baseMax -= 200000;
            }

            return new RangoTasacion
            {
                Min = baseMin,
                Max = baseMax
            };
        }

        public List<Tasacion> ObtenerTodas()
        {
            return _repo.ObtenerTodos();
        }
    }
}
