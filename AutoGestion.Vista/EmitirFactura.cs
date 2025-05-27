using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class EmitirFactura : UserControl
    {
        private readonly VentaBLL _ventaBLL = new();
        private readonly FacturaBLL _facturaBLL = new();

        public EmitirFactura()
        {
            InitializeComponent();
            CargarVentas();
        }

        private void CargarVentas()
        {
            dgvVentas.DataSource = null;
            var lista = _ventaBLL.ObtenerVentasPendientes()
                                 .Where(v => v.Estado == "Autorizada")
                                 .ToList();
            dgvVentas.DataSource = lista;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null) return;

            int index = dgvVentas.CurrentRow.Index;
            var venta = _ventaBLL.ObtenerVentasPendientes().Where(v => v.Estado == "Autorizada").ToList()[index];

            var factura = new Factura
            {
                Cliente = venta.Cliente,
                Vehiculo = venta.Vehiculo,
                Precio = venta.Total,
                FormaPago = venta.Pago.TipoPago
            };

            _facturaBLL.EmitirFactura(factura);
            _ventaBLL.MarcarComoFacturada(venta.ID);

            MessageBox.Show("Factura emitida correctamente.");
            CargarVentas();
        }
    }
}
