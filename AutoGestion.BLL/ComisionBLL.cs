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

        public List<Comision> ObtenerComisionesPorVendedor(string nombre)
        {
            return _repo.ObtenerTodos()
                .Where(c => c.Venta.Cliente.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Comision> FiltrarComisiones(List<Comision> lista, string estado = "", DateTime? desde = null, DateTime? hasta = null)
        {
            var query = lista.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(estado))
                query = query.Where(c => c.Estado == estado);

            if (desde.HasValue)
                query = query.Where(c => c.Fecha >= desde.Value);

            if (hasta.HasValue)
                query = query.Where(c => c.Fecha <= hasta.Value);

            return query.ToList();
        }

    }
}
