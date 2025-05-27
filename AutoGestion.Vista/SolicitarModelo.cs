using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class SolicitarModelo : UserControl
    {
        private readonly VehiculoBLL _vehiculoBLL = new();

        public SolicitarModelo()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string modelo = txtModelo.Text.Trim();
                if (string.IsNullOrEmpty(modelo))
                {
                    MessageBox.Show("Por favor ingrese un modelo.");
                    return;
                }

                List<Vehiculo> lista = _vehiculoBLL.BuscarVehiculosPorModelo(modelo);

                if (lista.Count == 0)
                {
                    lista = _vehiculoBLL.BuscarVehiculosSimilares(modelo);
                    if (lista.Count == 0)
                    {
                        MessageBox.Show("No se encontraron vehículos disponibles.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron coincidencias exactas. Se muestran vehículos similares.");
                    }
                }

                dgvResultados.DataSource = null;
                dgvResultados.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar vehículos: " + ex.Message);
            }
        }
    }
}
