using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class RegistrarComision : UserControl
    {
        private readonly ComisionBLL _comisionBLL = new();
        private readonly VentaBLL _ventaBLL = new();
        private List<Venta> _ventasDisponibles;

        public RegistrarComision()
        {
            InitializeComponent();
            cmbEstado.Items.AddRange(new[] { "Pendiente", "Pagada" });
            CargarVentas();
        }

        private void CargarVentas()
        {
            var comisiones = _comisionBLL.ObtenerTodas();
            _ventasDisponibles = _ventaBLL.ObtenerVentasSinComision(comisiones);

            dgvVentas.DataSource = null;
            dgvVentas.DataSource = _ventasDisponibles;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta.");
                return;
            }

            if (!decimal.TryParse(txtPorcentaje.Text, out decimal porcentaje) || porcentaje <= 0)
            {
                MessageBox.Show("Ingrese un porcentaje válido.");
                return;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el estado de la comisión.");
                return;
            }

            int index = dgvVentas.CurrentRow.Index;
            var venta = _ventasDisponibles[index];

            var comision = new Comision
            {
                Venta = venta,
                Porcentaje = porcentaje,
                Estado = cmbEstado.SelectedItem.ToString()
            };

            _comisionBLL.RegistrarComision(comision);
            MessageBox.Show("Comisión registrada correctamente.");
            CargarVentas();
        }
    }
}
