using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class RealizarEntrega : UserControl
    {
        private readonly VentaBLL _ventaBLL = new();
        private readonly ComprobanteBLL _comprobanteBLL = new();

        public RealizarEntrega()
        {
            InitializeComponent();
            CargarVentas();
        }

        private void CargarVentas()
        {
            dgvEntregas.DataSource = null;
            var lista = _ventaBLL.ObtenerVentasPendientes()
                                 .Where(v => v.Estado == "Facturada")
                                 .ToList();
            dgvEntregas.DataSource = lista;
            dgvEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            if (dgvEntregas.CurrentRow == null) return;

            int index = dgvEntregas.CurrentRow.Index;
            var venta = _ventaBLL.ObtenerVentasPendientes().Where(v => v.Estado == "Facturada").ToList()[index];

            // Actualizar venta
            _ventaBLL.MarcarComoEntregada(venta.ID);

            // Registrar comprobante
            var comprobante = new ComprobanteEntrega { Venta = venta };
            _comprobanteBLL.RegistrarComprobante(comprobante);

            MessageBox.Show("Entrega confirmada y comprobante generado.");
            CargarVentas();
        }
    }
}
