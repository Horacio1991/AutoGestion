using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutoGestion.Entidades.Seguridad;
using AutoGestion.Servicios;

namespace AutoGestion.Vista
{
    public partial class FormLogin : Form
    {
        private List<Usuario> _usuarios = new();

        public FormLogin()
        {
            InitializeComponent();
            Load += FormLogin_Load;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            _usuarios = UsuarioXmlService.Leer();

            // Opcional: mostrar usuarios cargados (para pruebas)
            if (_usuarios.Count == 0)
                MessageBox.Show("No hay usuarios cargados en el sistema.");
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

            // Guardar en sesión
            Sesion.UsuarioActual = usuario;

            // Abrir FormMain
            Form1 formMain = new Form1();
            formMain.Show();
            this.Hide();
        }
    }
}
