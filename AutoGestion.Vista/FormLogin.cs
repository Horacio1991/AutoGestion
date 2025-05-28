using AutoGestion.BE.Seguridad;
using AutoGestion.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoGestion.Vista
{
    public partial class FormLogin : Form
    {
        private List<Usuario> _usuarios = new List<Usuario>();

        public FormLogin()
        {
            InitializeComponent();
            CargarUsuariosDePrueba(); // Temporal
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombre = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            var usuario = _usuarios.FirstOrDefault(u =>
                u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                u.Clave == clave);

            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                return;
            }

            // Guardamos en sesión
            Sesion.UsuarioActual = usuario;

            // Abrimos el menú principal
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }

        // Esto lo vamos a reemplazar por XML luego
        private void CargarUsuariosDePrueba()
        {
            var venta = new PermisoCompuesto { Nombre = "Gestión de Ventas" };
            venta.Agregar(new PermisoSimple { Nombre = "Registrar Venta" });
            venta.Agregar(new PermisoSimple { Nombre = "Emitir Factura" });

            _usuarios.Add(new Usuario
            {
                Nombre = "admin",
                Clave = "123",
                Rol = venta
            });
        }
    }
}
