using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class RegistrarTurno : UserControl
    {
        private readonly TurnoBLL _turnoBLL = new();
        private readonly ClienteBLL _clienteBLL = new();
        private readonly VehiculoBLL _vehiculoBLL = new();

        public RegistrarTurno()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string dni = txtDniCliente.Text.Trim();
            string dominio = txtDominio.Text.Trim();
            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;

            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(dominio))
            {
                MessageBox.Show("Complete los campos requeridos.");
                return;
            }

            if (!_turnoBLL.VerificarDisponibilidad(fecha, hora))
            {
                MessageBox.Show("Ya existe un turno en esa fecha y hora.");
                return;
            }

            var cliente = _clienteBLL.BuscarClientePorDNI(dni);
            var vehiculo = _vehiculoBLL.BuscarVehiculoPorDominio(dominio);

            if (cliente == null || vehiculo == null)
            {
                MessageBox.Show("Cliente o vehículo no encontrado.");
                return;
            }

            var turno = new Turno
            {
                Cliente = cliente,
                Vehiculo = vehiculo,
                Fecha = fecha,
                Hora = hora
            };

            _turnoBLL.RegistrarTurno(turno);
            MessageBox.Show("Turno registrado correctamente.");
            Limpiar();
        }

        private void Limpiar()
        {
            txtDniCliente.Clear();
            txtDominio.Clear();
            dtpFecha.Value = DateTime.Today;
            dtpHora.Value = DateTime.Today.AddHours(9);
        }
    }
}
