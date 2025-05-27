using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class EvaluarEstado : UserControl
    {
        private readonly OfertaBLL _ofertaBLL = new();
        private readonly EvaluacionBLL _evaluacionBLL = new();
        private List<OfertaCompra> _ofertasDisponibles;

        public EvaluarEstado()
        {
            InitializeComponent();
            CargarOfertas();
        }

        private void CargarOfertas()
        {
            _ofertasDisponibles = _ofertaBLL.ObtenerOfertasConInspeccion();
            cmbOfertas.DataSource = _ofertasDisponibles;
            cmbOfertas.DisplayMember = "Vehiculo.Dominio";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbOfertas.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una oferta.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotor.Text) ||
                string.IsNullOrWhiteSpace(txtCarroceria.Text) ||
                string.IsNullOrWhiteSpace(txtInterior.Text) ||
                string.IsNullOrWhiteSpace(txtDocumentacion.Text))
            {
                MessageBox.Show("Complete todos los campos técnicos.");
                return;
            }

            var evaluacion = new EvaluacionTecnica
            {
                EstadoMotor = txtMotor.Text,
                EstadoCarroceria = txtCarroceria.Text,
                EstadoInterior = txtInterior.Text,
                EstadoDocumentacion = txtDocumentacion.Text,
                Observaciones = txtObservaciones.Text
            };

            _evaluacionBLL.GuardarEvaluacion(evaluacion);
            MessageBox.Show("Evaluación registrada correctamente.");
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtMotor.Clear();
            txtCarroceria.Clear();
            txtInterior.Clear();
            txtDocumentacion.Clear();
            txtObservaciones.Clear();
            cmbOfertas.SelectedIndex = -1;
        }
    }
}
