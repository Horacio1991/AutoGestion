using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class AutorizarVenta : UserControl
    {
        private readonly VentaBLL _ventaBLL = new();

        public AutorizarVenta()
        {
            InitializeComponent();
            CargarVentas();
        }

        private void CargarVentas()
        {
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = _ventaBLL.ObtenerVentasPendientes();
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null) return;

            int index = dgvVentas.CurrentRow.Index;
            _ventaBLL.AutorizarVenta(index);
            MessageBox.Show("Venta autorizada.");
            CargarVentas();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null) return;

            int index = dgvVentas.CurrentRow.Index;
            _ventaBLL.RechazarVenta(index);
            MessageBox.Show("Venta rechazada.");
            CargarVentas();
        }
    }
}
