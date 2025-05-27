using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class TasarVehiculo : UserControl
    {
        private readonly OfertaBLL _ofertaBLL = new();
        private readonly EvaluacionBLL _evaluacionBLL = new();
        private readonly TasaBLL _tasaBLL = new();
        private readonly VehiculoBLL _vehiculoBLL = new();
        private List<OfertaCompra> _ofertasEvaluadas;

        public TasarVehiculo()
        {
            InitializeComponent();
            CargarOfertas();
            cmbEstadoStock.Items.AddRange(new[] { "Disponible", "Requiere reacondicionamiento" });
        }

        private void CargarOfertas()
        {
            _ofertasEvaluadas = _ofertaBLL.ObtenerTodas(); // filtrá si querés solo con evaluación
            cmbOfertas.DataSource = _ofertasEvaluadas;
            cmbOfertas.DisplayMember = "Vehiculo.Dominio";
        }

        private void cmbOfertas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var oferta = (OfertaCompra)cmbOfertas.SelectedItem;
            var evaluacion = _evaluacionBLL.ObtenerTodas().FirstOrDefault();

            if (evaluacion != null)
            {
                txtEvaluacion.Text = $"Motor: {evaluacion.EstadoMotor}, Carrocería: {evaluacion.EstadoCarroceria}";
                var rango = _tasaBLL.CalcularRangoTasacion(evaluacion);
                txtRango.Text = rango != null ? $"Entre {rango?.Min:C} y {rango?.Max:C}" : "Sin sugerencia";
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtValorFinal.Text, out decimal valorFinal))
            {
                MessageBox.Show("Ingrese un valor válido.");
                return;
            }

            if (cmbEstadoStock.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione estado de stock.");
                return;
            }

            var oferta = (OfertaCompra)cmbOfertas.SelectedItem;

            _tasaBLL.RegistrarTasacion(oferta, valorFinal);
            _vehiculoBLL.ActualizarEstadoStock(oferta.Vehiculo, cmbEstadoStock.SelectedItem.ToString());

            MessageBox.Show("Tasación registrada correctamente.");
        }
    }
}
