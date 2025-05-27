using AutoGestion.BE;
using AutoGestion.BLL;
using System;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class RegistrarOferta : UserControl
    {
        private readonly OferenteBLL _oferenteBLL = new();
        private readonly OfertaBLL _ofertaBLL = new();
        private Oferente _oferenteActual = null;

        public RegistrarOferta()
        {
            InitializeComponent();
        }

        private void btnBuscarDni_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Ingrese un DNI.");
                return;
            }

            _oferenteActual = _oferenteBLL.BuscarPorDni(dni);

            if (_oferenteActual != null)
            {
                txtNombre.Text = _oferenteActual.Nombre;
                txtApellido.Text = _oferenteActual.Apellido;
                txtContacto.Text = _oferenteActual.Contacto;
                MessageBox.Show("Oferente encontrado.");
            }
            else
            {
                txtNombre.Clear();
                txtApellido.Clear();
                txtContacto.Clear();
                MessageBox.Show("Oferente no encontrado. Ingrese los datos para registrarlo.");
            }
        }

        private void btnRegistrarOferta_Click(object sender, EventArgs e)
        {
            // Validar oferente
            string dni = txtDni.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string contacto = txtContacto.Text.Trim();

            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(contacto))
            {
                MessageBox.Show("Complete todos los campos del oferente.");
                return;
            }

            if (_oferenteActual == null)
            {
                _oferenteActual = new Oferente
                {
                    Dni = dni,
                    Nombre = nombre,
                    Apellido = apellido,
                    Contacto = contacto
                };
                _oferenteBLL.GuardarOferente(_oferenteActual);
            }

            // Validar vehículo
            string marca = txtMarca.Text.Trim();
            string modelo = txtModelo.Text.Trim();
            string color = txtColor.Text.Trim();
            string dominio = txtDominio.Text.Trim();
            if (!int.TryParse(txtAño.Text, out int año) || !int.TryParse(txtKm.Text, out int km))
            {
                MessageBox.Show("Año y kilómetros deben ser numéricos.");
                return;
            }

            if (string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(dominio))
            {
                MessageBox.Show("Complete todos los campos del vehículo.");
                return;
            }

            Vehiculo vehiculo = new Vehiculo
            {
                Marca = marca,
                Modelo = modelo,
                Año = año,
                Color = color,
                Km = km,
                Dominio = dominio,
                Estado = "Pendiente"
            };

            // Validar duplicado
            if (_ofertaBLL.ValidarOfertaDuplicada(vehiculo))
            {
                MessageBox.Show("Ya existe una oferta registrada para este vehículo.");
                return;
            }

            OfertaCompra oferta = new OfertaCompra
            {
                Oferente = _oferenteActual,
                Vehiculo = vehiculo,
                FechaInspeccion = dtpFechaInspeccion.Value
            };

            _ofertaBLL.RegistrarOferta(oferta);
            MessageBox.Show("Oferta registrada correctamente.");
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtContacto.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtAño.Clear();
            txtColor.Clear();
            txtKm.Clear();
            txtDominio.Clear();
            dtpFechaInspeccion.Value = DateTime.Today;
            _oferenteActual = null;
        }
    }
}
