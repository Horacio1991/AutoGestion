using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class ConsultarComisiones : UserControl
    {
        private readonly ComisionBLL _comisionBLL = new();
        private List<Comision> _comisiones = new();

        public ConsultarComisiones()
        {
            InitializeComponent();
            cmbEstado.Items.AddRange(new[] { "", "Pendiente", "Pagada" });
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string nombre = txtVendedor.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese el nombre del vendedor.");
                return;
            }

            _comisiones = _comisionBLL.ObtenerComisionesPorVendedor(nombre);

            string estado = cmbEstado.SelectedItem?.ToString();
            DateTime? desde = dtpDesde.Checked ? dtpDesde.Value.Date : null;
            DateTime? hasta = dtpHasta.Checked ? dtpHasta.Value.Date : null;

            var filtradas = _comisionBLL.FiltrarComisiones(_comisiones, estado, desde, hasta);

            dgvComisiones.DataSource = null;
            dgvComisiones.DataSource = filtradas;
            dgvComisiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una comisión.");
                return;
            }

            int index = dgvComisiones.CurrentRow.Index;
            var comision = ((List<Comision>)dgvComisiones.DataSource)[index];

            MessageBox.Show(
                $"Venta ID: {comision.Venta.ID}\n" +
                $"Porcentaje: {comision.Porcentaje}%\n" +
                $"Monto: {comision.Monto:C}\n" +
                $"Fecha: {comision.Fecha:d}\n" +
                $"Estado: {comision.Estado}",
                "Detalle de Comisión"
            );
        }
    }
}
