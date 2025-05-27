using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class RealizarPago : UserControl
    {
        private readonly PagoBLL _pagoBLL = new();

        public RealizarPago()
        {
            InitializeComponent();
            cmbTipoPago.Items.AddRange(new[] { "Contado", "Financiado" });
            cmbTipoPago.SelectedIndex = 0;
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = cmbTipoPago.SelectedItem.ToString();
                if (!decimal.TryParse(txtMonto.Text, out decimal monto))
                {
                    MessageBox.Show("Ingrese un monto válido.");
                    return;
                }

                int cuotas = 1;
                if (tipo == "Financiado")
                {
                    if (!int.TryParse(txtCuotas.Text, out cuotas) || cuotas <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad válida de cuotas.");
                        return;
                    }
                }

                var pago = new Pago
                {
                    TipoPago = tipo,
                    Monto = monto,
                    Cuotas = cuotas,
                    Detalles = txtDetalles.Text
                };

                bool ok = _pagoBLL.RegistrarPago(pago);

                if (ok)
                    MessageBox.Show("Pago registrado con éxito.");
                else
                    MessageBox.Show("Error al registrar el pago.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    



        private void cmbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
                txtCuotas.Enabled = cmbTipoPago.SelectedItem.ToString() == "Financiado"; 
        }
    }
}
