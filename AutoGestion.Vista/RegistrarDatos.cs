using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class RegistrarDatos : UserControl
    {
        private readonly OfertaBLL _ofertaBLL = new();
        private readonly VehiculoBLL _vehiculoBLL = new();
        private readonly PagoBLL _pagoBLL = new();
        private OfertaCompra _ofertaActual = null;

        public RegistrarDatos()
        {
            InitializeComponent();
            cmbTipoPago.Items.AddRange(new[] { "Contado", "Transferencia", "Cheque" });
            cmbEstadoStock.Items.AddRange(new[] { "Disponible", "Requiere reacondicionamiento" });
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dominio = txtDominio.Text.Trim();
            _ofertaActual = _ofertaBLL.ObtenerTodas()
                .Find(o => o.Vehiculo.Dominio == dominio);

            if (_ofertaActual == null)
            {
                MessageBox.Show("Oferta no encontrada.");
                return;
            }

            MessageBox.Show("Oferta encontrada. Complete los datos.");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (_ofertaActual == null)
            {
                MessageBox.Show("Busque una oferta válida primero.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDatosTecnicos.Text) ||
                cmbTipoPago.SelectedIndex == -1 || cmbEstadoStock.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            _vehiculoBLL.ActualizarDatosVehiculo(_ofertaActual.Vehiculo, txtDatosTecnicos.Text);
            _vehiculoBLL.ActualizarEstadoStock(_ofertaActual.Vehiculo, cmbEstadoStock.SelectedItem.ToString());

            var pago = new Pago
            {
                TipoPago = cmbTipoPago.SelectedItem.ToString(),
                Monto = 0,
                Cuotas = 1,
                Detalles = txtDetallesPago.Text
            };

            _pagoBLL.RegistrarPago(pago);

            MessageBox.Show("Datos registrados correctamente.");
            Limpiar();
        }

        private void Limpiar()
        {
            txtDominio.Clear();
            txtDatosTecnicos.Clear();
            txtDetallesPago.Clear();
            cmbTipoPago.SelectedIndex = -1;
            cmbEstadoStock.SelectedIndex = -1;
            _ofertaActual = null;
        }
    }
}
