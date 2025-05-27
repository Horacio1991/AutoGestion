using AutoGestion.BE;
using AutoGestion.CTRL_Vista;
using System;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class RegistrarCliente : UserControl
    {
        private readonly ClienteController _controller = new();

        public RegistrarCliente()
        {
            InitializeComponent();
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDni.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string contacto = txtContacto.Text;

                var existente = _controller.BuscarCliente(dni);

                if (existente != null)
                {
                    MessageBox.Show($"El cliente ya existe:\n" +
                        $"{existente.Nombre} {existente.Apellido}\nContacto: {existente.Contacto}",
                        "Cliente encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var nuevo = _controller.RegistrarCliente(dni, nombre, apellido, contacto);
                MessageBox.Show("Cliente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos
                txtDni.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtContacto.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
