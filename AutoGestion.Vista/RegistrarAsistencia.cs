using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class RegistrarAsistencia : UserControl
    {
        private readonly TurnoBLL _turnoBLL = new();
        private List<Turno> _turnosVencidos;

        public RegistrarAsistencia()
        {
            InitializeComponent();
            cmbEstado.Items.AddRange(new[] { "Asistió", "No asistió" });
            CargarTurnos();
        }

        private void CargarTurnos()
        {
         //   _turnosVencidos = _turnoBLL.ObtenerTurnosVencidos();
            dgvTurnos.DataSource = null;
            dgvTurnos.DataSource = _turnosVencidos;
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow == null || cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un turno y un estado.");
                return;
            }

            int index = dgvTurnos.CurrentRow.Index;
            var turno = _turnosVencidos[index];

          //  _turnoBLL.RegistrarAsistencia(turno.ID, cmbEstado.SelectedItem.ToString());

            if (!string.IsNullOrWhiteSpace(txtObservaciones.Text))
            {
               // _turnoBLL.RegistrarObservaciones(turno.ID, txtObservaciones.Text);
            }

            MessageBox.Show("Asistencia actualizada.");
            CargarTurnos();
        }
    }
}
