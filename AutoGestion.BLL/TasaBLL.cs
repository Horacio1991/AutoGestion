using AutoGestion.BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoGestion.BLL
{
    public class TasaBLL
    {
        private readonly Dictionary<string, (decimal Min, decimal Max)> _valoresReferencia;

        public TasaBLL()
        {
            _valoresReferencia = new Dictionary<string, (decimal, decimal)>
            {
                { "Excelente", (2500000, 3000000) },
                { "Muy bueno", (2000000, 2500000) },
                { "Regular", (1500000, 2000000) }
            };
        }

        public (decimal Min, decimal Max)? CalcularRangoTasacion(EvaluacionTecnica eval)
        {
            string estadoGlobal = ObtenerEstadoGlobal(eval);

            if (_valoresReferencia.ContainsKey(estadoGlobal))
                return _valoresReferencia[estadoGlobal];

            return null;
        }

        private string ObtenerEstadoGlobal(EvaluacionTecnica e)
        {
            var estados = new[] { e.EstadoMotor, e.EstadoCarroceria, e.EstadoInterior, e.EstadoDocumentacion };
            if (estados.All(s => s == "Excelente")) return "Excelente";
            if (estados.All(s => s == "Muy bueno" || s == "Excelente")) return "Muy bueno";
            return "Regular";
        }

        public void RegistrarTasacion(OfertaCompra oferta, decimal valorFinal)
        {
            oferta.Vehiculo.Estado = "Tasar: " + valorFinal.ToString("C");
            // Podés guardar la oferta actualizada o loguear la tasación
        }
    }
}
