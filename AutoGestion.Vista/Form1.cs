using AutoGestion.Entidades.Seguridad;


namespace AutoGestion.Vista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuRegistrarCliente_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarCliente();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuSolicitarModelo_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new SolicitarModelo();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRealizarPago_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RealizarPago();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuAutorizarVenta_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new AutorizarVenta();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuEmitirFactura_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new EmitirFactura();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRealizarEntrega_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RealizarEntrega();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRegistrarOferta_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarOferta();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuEvaluarVehiculo_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new EvaluarEstado();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuTasarVehiculo_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new TasarVehiculo();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRegistrarCompra_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarDatos();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRegistrarComision_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarComision();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuConsultarComisiones_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new ConsultarComisiones();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRegistrarTurno_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarTurno();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRegistrarAsistencia_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarAsistencia();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void asignarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new AsignarRoles();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var usuario = Sesion.UsuarioActual;

            // Si es superadmin, ve todo
            if (usuario.Nombre.ToLower() == "admin")
                return;
        }

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Seguro que querés cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                Sesion.UsuarioActual = null;

                // Volver al login
                FormLogin login = new FormLogin();
                login.Show();

                this.Close(); // cerrar el FormMain
            }
        }

        private void aBMUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            panelContenido.Controls.Clear();
            var control = new ABMUsuarios();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);

        }
    }
}
